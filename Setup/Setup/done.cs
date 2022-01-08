using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Setup
{
    public partial class done : Form
    {
        public done()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void done_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
