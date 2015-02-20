using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mw360launcher
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void eng_Click(object sender, EventArgs e)
        {
            this.Hide();
            Directory.CreateDirectory("C:\\MantouWeb360\\eng");
            zhlauncherform engform = new zhlauncherform();
            engform.ShowDialog();
            this.Close();
        }

        private void zh_Click(object sender, EventArgs e)
        {
            this.Hide();
            Directory.CreateDirectory("C:\\MantouWeb360\\zh");
            zhForm1 zhform = new zhForm1();
            zhform.ShowDialog();
            this.Close();
        }

    }
}
