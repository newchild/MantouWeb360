using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BrowserDoctorHelper
{
    public partial class bdform : Form
    {
        public bdform()
        {
            InitializeComponent();

        }

        private void ctimer_Tick(object sender, EventArgs e)
        {
            ctimer.Stop();
            Application.Exit();
        }

        private void bdform_Load(object sender, EventArgs e)
        {
            string process = "MantouWeb360";
            if (Process.GetProcessesByName(process).Length == 0)
            {
                Application.Exit();
            }
            else
            {
                int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                this.Location = new Point(x, y);
            }
            
        }
    }
}
