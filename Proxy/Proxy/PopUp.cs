using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    public partial class PopUp : Form
    {
        public PopUp(string context)
        {
            InitializeComponent();

            this.headersTxt.Text = context;
        }
    }
}
