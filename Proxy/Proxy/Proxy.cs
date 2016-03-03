using System;
using System.Threading;
using System.Windows.Forms;

namespace Proxy
{
    public partial class Proxy : Form
    {
        /// <summary>
        /// Constructor proxy
        /// </summary>
        public Proxy()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires when a user presses the start proxy button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _BtnStart_Click(object sender, EventArgs e)
        {
            var proxy = new Listener(9000, _addTextToLstChat);
            proxy.StartListener();

            var t = new Thread(delegate()
            {
                // Infinite loop to accept connections when one connection occures
                while (true)
                {
                    proxy.AcceptConnection();
                }  
            });
            t.Start();
        }

        /// <summary>
        /// Adds any input string to the lstChat form element. It will put every message on a seperate new line
        /// </summary>
        /// <param name="input">The input that will be printed</param>
        private void _addTextToLstChat(string input)
        {
            Invoke(new Action(() =>
            {
                logTxt.AppendText(input);
                logTxt.AppendText(Environment.NewLine);
            }));
        }

    }
}
