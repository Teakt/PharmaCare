using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhramaCare
{
    public partial class MDIContainer : Form
    {
        public MDIContainer()
        {
            InitializeComponent();
        }

        private void ShowForm(Form frm)
        {

            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(Register.Instance);
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(Form1.Instance);
        }
    }
}
