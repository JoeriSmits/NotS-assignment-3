using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

                // Print the request to the log box
                _printTextDelegate("Request Received...");
                _printTextDelegate(requestPayload);

                //State 1: Rebuilding Request Information and Create Connection to Destination Server
                var remoteHost = requestLines[0].Split(' ')[1].Replace("http://", "").Split('/')[0];
                var requestFile = requestLines[0].Replace("http://", "").Replace(remoteHost, "");
                requestLines[0] = requestFile;

                requestPayload = "";
                foreach (var line in requestLines)
                {
                    requestPayload += line;
                    requestPayload += eol;
                }

                // Connect to a remoteHost
                var destServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                destServerSocket.Connect(remoteHost, 80);

                //State 2: Sending New Request Information to Destination Server and Relay Response to Client
                destServerSocket.Send(Encoding.ASCII.GetBytes(requestPayload));

                while (destServerSocket.Receive(responseBuffer) != 0)
                {
                    this._clientSocket.Send(responseBuffer);
                }

                destServerSocket.Disconnect(false);
                destServerSocket.Dispose();
                this._clientSocket.Disconnect(false);
                this._clientSocket.Dispose();
            }
            catch (Exception e)
            {
                _printTextDelegate("Error Occured: " + e.Message);
            }
        }
    }
}
