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
        public static int CacheTimeValue = 0;

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

        /// <summary>
        /// Clears the log list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrBtn_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                logTxt.Items.Clear();
            }));
        }

        /// <summary>
        /// Open a new form when the user double clicks on an item in the log list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sets the port number that the user sends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortText_Blur(object sender, EventArgs e)
        {
            try
            {
                Port = Convert.ToInt32(portText.Text);

            }
            catch (FormatException)
            {
                _addTextToLst("Cannot use this port number. Port 9000 has been selected as it is default");
            }
        }

        /// <summary>
        /// Updates the state of the authChecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (authChecked != null)
            {
                CheckedAuth = authChecked.Checked;
            }
        }

        /// <summary>
        /// Sets the buffer size that the user sends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bufferSize_Blur(object sender, EventArgs e)
        {
            try
            {
                BufferSize = Convert.ToInt32(bufferSize.Text);
            }
            catch (FormatException)
            {
                _addTextToLst("Cannot use this buffer size. 1 has been selected as it is default");
            }
        }

        /// <summary>
        /// Sets the cache time out that the user sends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cacheTime_Blur(object sender, EventArgs e)
        {
            try
            {
                CacheTimeValue = Convert.ToInt32(cacheTime.Text) * 1000;
            }
            catch (FormatException)
            {
                _addTextToLst("Cannot use this timeout. Please use numbers to indicate the nr of seconds. 0 has been selected as it is default");
            }
        }
    }
}
