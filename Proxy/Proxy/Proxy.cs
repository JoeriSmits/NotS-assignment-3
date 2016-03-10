using System;
using System.Threading;
using System.Windows.Forms;

namespace Proxy
{
    public partial class Proxy : Form
    {
        public static int Port = 9000;
        public static int BufferSize = 1;
        public static bool CheckedAuth;
       
        /// <summary>
        /// Constructor proxy
        /// </summary>
        public Proxy()
        {
            InitializeComponent();
        }

        public CheckBox UserAuthCheck { get; set; }

        /// <summary>
        /// Fires when a user presses the start proxy button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _BtnStart_Click(object sender, EventArgs e)
        {
            var proxy = new Listener(Port, _addTextToLst);
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
        private void _addTextToLst(string input)
        {
            Invoke(new Action(() =>
            {
                logTxt.Items.Add(input);

                // Scroll down to the last item
                var visibleItems = logTxt.ClientSize.Height / logTxt.ItemHeight;
                logTxt.TopIndex = Math.Max(logTxt.Items.Count - visibleItems + 1, 0);
            }));
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                logTxt.Items.Clear();
            }));
        }

        private void logTxt_DoubleClick(object sender, MouseEventArgs e)
        {
            Invoke(new Action(() =>
            {
                var index = logTxt.IndexFromPoint(e.Location);
                var content = logTxt.Items[index].ToString();
                var form = new PopUp(content);
                form.Show();
            }));
        }

        private void PortText_Blur(object sender, EventArgs e)
        {
            Port = Convert.ToInt32(portText.Text);
        }

        private void authChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (authChecked != null)
            {
                CheckedAuth = authChecked.Checked;
            }
        }

        private void bufferSize_Blur(object sender, EventArgs e)
        {
            BufferSize = Convert.ToInt32(bufferSize.Text);
        }
    }
}
