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

        private static MDIContainer _instance;

        public static MDIContainer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MDIContainer();
                return _instance;

            }
        }

        private void ShowForm(Form frm)
        {
            frm.Show();
            frm.Activate();
            this.Hide();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MDIContainer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm(Form1.Instance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowForm(Register.Instance);  
        }
    }
}
