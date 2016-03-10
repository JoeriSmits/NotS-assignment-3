﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    internal class ClientConnection
    {
        private readonly Socket _clientSocket;
        public delegate void PrintTextDelegate(string input);
        private readonly PrintTextDelegate _printTextDelegate;

        /// <summary>
        /// Constructor ClientConnection
        /// Set's the clientSocket property to the client
        /// </summary>
        /// <param name="client">The socket of the client</param>
        /// <param name="printTextDelegate">The delegate to send the output to.</param>
        public ClientConnection(Socket client, PrintTextDelegate printTextDelegate)
        {
            this._printTextDelegate = printTextDelegate;
            this._clientSocket = client;
        }

        /// <summary>
        /// Start the handler in a new Thread. We give this thread priority above all other threads.
        /// </summary>
        public void StartHandling()
        {
            var t = new Thread(Handler) {Priority = ThreadPriority.AboveNormal};
            t.Start();
        }

        /// <summary>
        /// Get's the client's request
        /// </summary>
        private void Handler()
        {
            var recvRequest = true;
            const string eol = "\r\n";

            var requestPayload = "";
            var requestTempLine = "";
            var requestLines = new List<string>();
            var requestBuffer = new byte[Proxy.BufferSize];
            var responseBuffer = new byte[Proxy.BufferSize];

            requestLines.Clear();

            // Check if there are no errors
            try
            {
                //State 0: Handle Request from Client
                while (recvRequest)
                {
                    // Safe the input of _clientSocket in requestBuffer
                    this._clientSocket.Receive(requestBuffer);

                    // Encode the requestBuffer from bytes to a string
                    var fromByte = Encoding.ASCII.GetString(requestBuffer);
                    requestPayload += fromByte;
                    requestTempLine += fromByte;

                    // Check if the client request has ended
                    if (requestTempLine.EndsWith(eol))
                    {
                        requestLines.Add(requestTempLine.Trim());
                        requestTempLine = "";
                    }

                    if (requestPayload.EndsWith(eol + eol))
                    {
                        recvRequest = false;
                    }
                }

                // Rebuilding Request Information and Create Connection to Destination Server
                var remoteHost = requestLines[0].Split(' ')[1].Replace("http://", "").Split('/')[0];
                var requestFile = requestLines[0].Replace("http://", "").Replace(remoteHost, "");
                requestLines[0] = requestFile;

                requestPayload = "";
                var imageRequest = false;
                var imageExtension = "";
                foreach (var line in requestLines)
                {
                    var addLines = !(Proxy.CheckedAuth && line.Contains("User-Agent"));

                    if (line.Contains("Accept-Encoding"))
                    {
                        addLines = false;
                    }

                    if (line.Contains("Accept") && line.Contains("image"))
                    {
                        imageRequest = true;
                        imageExtension = "png";

                        if (line.Contains("jpg"))
                        {
                            imageExtension = "jpg";
                        }
                        if (line.Contains("gif"))
                        {
                            imageExtension = "gif";
                        }
                    }

                    if (addLines)
                    {
                        requestPayload += line;
                        requestPayload += eol;
                    }
                }

                // Print the request to the log boxd
                _printTextDelegate("> " + requestPayload);


                string response;
                if (!imageRequest)
                {
                    // Connect to a remoteHost
                    var destServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    destServerSocket.Connect(remoteHost, 80);

                    // Sending New Request Information to Destination Server and Relay Response to Client
                    destServerSocket.Send(Encoding.ASCII.GetBytes(requestPayload));

                    var receivedBytes = new List<byte>();
                    // Receiving the response bytes in the responseBuffer
                    while (destServerSocket.Receive(responseBuffer) != 0)
                    {
                        // Copying all bytes to the receivedBytes list
                        receivedBytes.Add(responseBuffer[0]);
                        this._clientSocket.Send(responseBuffer);
                    }

                    // Get the response and send it to the log
                    response = Encoding.UTF8.GetString(receivedBytes.ToArray());

                    // Close all connections
                    destServerSocket.Disconnect(false);
                    destServerSocket.Dispose();
                }
                else
                {
                    System.Drawing.Bitmap img = null;
                    if (imageExtension != "")
                    {
                        switch (imageExtension)
                        {
                            case "png":
                                img = Properties.Resources.placeholderPNG;
                                break;
                            case "jpg":
                                img = Properties.Resources.placeholderJPG;
                                break;
                            case "gif":
                                img = Properties.Resources.placeholderGIF;
                                break;
                            default:
                                img = Properties.Resources.placeholderPNG;
                                break;
                        }
                    }

                    byte[] byteImage;
                    if (img != null)
                    {
                        byteImage = ImageToByte(img);

                        response = "HTTP/1.1 200 OK" + eol + "Server: Joeri Proxy" + eol + "Accept-Ranges: bytes" +
                                   eol + "Content-Length: " + byteImage.Length + eol + "Connection: close" + eol + 
                                   "Content-Type: image/" + imageExtension + eol + "Date: " + DateTime.Now + eol + eol;

                        var responseHeader = Encoding.ASCII.GetBytes(response);
                        var mergedResponse = new byte[responseHeader.Length + byteImage.Length];
                        responseHeader.CopyTo(mergedResponse, 0);
                        byteImage.CopyTo(mergedResponse, responseHeader.Length);

                        var i = 0;
                        while (i < mergedResponse.Length)
                        {
                            responseBuffer[0] = mergedResponse[i];
                            this._clientSocket.Send(responseBuffer);
                            i++;
                        }

                        response = Encoding.UTF8.GetString(mergedResponse);
                    }
                    else
                    {
                        response = "HTTP/1.1 500 Internal Server Error";
                    }
                }
                _printTextDelegate("< " + response);
           
                this._clientSocket.Disconnect(false);
                this._clientSocket.Dispose();
            }
            catch (Exception e)
            {
                _printTextDelegate("Error Occured: " + e.Message);
            }           
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
