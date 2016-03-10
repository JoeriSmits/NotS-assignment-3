using System;
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
            var requestBuffer = new byte[1];
            var responseBuffer = new byte[1];

            requestLines.Clear();

            // Check if there are no errors
            try
            {
                //Handle Request from Client
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

                // Read the request
                requestPayload = "";
                var imageRequest = false;
                var imageExtension = "";
                foreach (var line in requestLines)
                {
                    // Initialize the addLines boolean. 
                    // If we have a checked checkbox and the line contains it will set it to false else it will set to true.
                    var addLines = !(Proxy.CheckedAuth && line.Contains("User-Agent"));
                    // If the line contains 'Accept-Encoding' we will remove the line from the request
                    if (line.Contains("Accept-Encoding"))
                    {
                        addLines = false;
                    }
                    // If the line contains Accept and image we will safe the image extension and say that it is a image request.
                    if (line.Contains("Accept") && line.Contains("image"))
                    {
                        imageRequest = true;
                        imageExtension = "png";

                        // Check what image extension the image is that is been requested
                        if (line.Contains("jpg"))
                        {
                            imageExtension = "jpg";
                        }
                        if (line.Contains("gif"))
                        {
                            imageExtension = "gif";
                        }
                    }
                    // If the addLines boolean has not been set to false we will add the lines to the request
                    if (addLines)
                    {
                        requestPayload += line;
                        requestPayload += eol;
                    }
                }

                // Print the request to the log boxd
                _printTextDelegate("> " + requestPayload);

                // Is the request not an image request?
                string response;
                if (!imageRequest)
                {
                    var cachedResponse = "";
                    // Check if the cachedObjectList is not null
                    if (CachedObject.CachedObjectsList != null)
                    {
                        // Loop though all the cachedObjects
                        foreach (var cache in CachedObject.CachedObjectsList)
                        {
                            // Check if the request has been cached earlier
                            if (cache.Request.Contains(requestPayload))
                            {
                                // The value has been cached and the cachedResponse will be equal to what there is in the saved list
                                cachedResponse = cache.Response;
                            }
                        }
                    }

                    // If there is a cached response we will send this to the client
                    if (cachedResponse != "")
                    {
                        // Get the response and send it to the log
                        var cachedResponseBytes = Encoding.ASCII.GetBytes(cachedResponse);
                        // Send the mergeResponse to the client socket
                        for (var i = 0; i < cachedResponseBytes.Length; i++)
                        {
                            responseBuffer[0] = cachedResponseBytes[i];
                            this._clientSocket.Send(responseBuffer);
                        }

                        response = "CACHED - " + cachedResponse;
                    }
                    // There is no cached response
                    else
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

                        // Add request and response to the cachedObjectsList
                        var cachedObject = new CachedObject(requestPayload, response);
                        if (CachedObject.CachedObjectsList != null) CachedObject.CachedObjectsList.Add(cachedObject);

                        // Close all connections
                        destServerSocket.Disconnect(false);
                        destServerSocket.Dispose();
                    }
                }
                // The request is an image request
                else
                {
                    // We will get the correct resource according to what image extension the requested file is.
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
                    // Check if the image (resource) is not null. Is the image available in resources?
                    if (img != null)
                    {
                        // Convert the image to a bytes aray
                        byteImage = ImageToByte(img);

                        var cacheHeaders = "";
                        if (Proxy.CacheTimeValue > 0)
                        {
                            cacheHeaders = "Cache-Control: no-transform,public,max-age=" + Proxy.CacheTimeValue + eol;
                        }

                        // Create a custom response for the image
                        response = "HTTP/1.1 200 OK" + eol + cacheHeaders +
                                    "Server: Joeri Proxy" + eol + "Accept-Ranges: bytes" +
                                   eol + "Content-Length: " + byteImage.Length + eol + "Connection: close" + eol + 
                                   "Content-Type: image/" + imageExtension + eol + "Date: " + DateTime.Now + eol + eol;

                        // Concatenate the headers and the image and convert them to bytes for transport 
                        var responseHeader = Encoding.ASCII.GetBytes(response);
                        var mergedResponse = new byte[responseHeader.Length + byteImage.Length];
                        responseHeader.CopyTo(mergedResponse, 0);
                        byteImage.CopyTo(mergedResponse, responseHeader.Length);

                        // Send the mergeResponse to the client socket
                        for (var i = 0; i < mergedResponse.Length; i++)
                        {
                            responseBuffer[0] = mergedResponse[i];
                            this._clientSocket.Send(responseBuffer);
                        }

                        response = "IMAGED REPLACED - " + Encoding.UTF8.GetString(mergedResponse);
                    }
                    // If we cannot get the resource we will send a 500 internal server error to the client log lstBox
                    else
                    {
                        response = "HTTP/1.1 500 Internal Server Error";
                    }
                }
                // Print the response to the log lstBox
                _printTextDelegate("< " + response);
           
                // Close the clientSocket
                this._clientSocket.Disconnect(false);
                this._clientSocket.Dispose();
            }
            // If there was an error we will print this error to the log lstBox
            catch (Exception e)
            {
                _printTextDelegate("Error Occured: " + e.Message);
            }           
        }

        /// <summary>
        /// Convert an image bitmap to an array of bytes
        /// </summary>
        /// <param name="img">the image in resources</param>
        /// <returns>byte array of the image</returns>
        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
