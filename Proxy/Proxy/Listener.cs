using System.Net;
using System.Net.Sockets;

namespace Proxy
{
    internal class Listener 
    {
        private readonly int _listenPort;
        private readonly TcpListener listener;
        public delegate void PrintTextDelegate(string input);
        private readonly PrintTextDelegate _printTextDelegate;

        /// <summary>
        /// Constructor listener
        /// Set's the port of the proxy and passes a printTextDelegate to output text
        /// </summary>
        /// <param name="port">Port of the proxy</param>
        /// <param name="printTextDelegate">delegate to output text</param>
        public Listener(int port, PrintTextDelegate printTextDelegate)
        {
            this._printTextDelegate = printTextDelegate;
            this._listenPort = port;
            this.listener = new TcpListener(IPAddress.Any, this._listenPort);
        }

        /// <summary>
        /// Start the proxy
        /// </summary>
        public void StartListener()
        {
            _printTextDelegate("Proxy started");
            this.listener.Start();
        }

        /// <summary>
        /// Accept a connection from a client we start a clientConnection once the socket has been accepted
        /// </summary>
        public void AcceptConnection()
        {
            var newClient = this.listener.AcceptSocket();
            var client = new ClientConnection(newClient, delegate(string input)
            {
                _printTextDelegate(input);
            });
            client.StartHandling();
        }
    }
}
