//(C) Copyright 2014 MantouDev, MantouDev Technologies
//DISTRIBUTION OR MODIFICATION OF THIS CODE IS STRICTLY PROHIBITED
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MantouWeb360
{
    public partial class loadScreenForm : Form
    {
        public loadScreenForm()
        {
            InitializeComponent();
        }

        private void loadScreenForm_Load(object sender, EventArgs e)
        {
            
        }

        private void passtime_Tick(object sender, EventArgs e)
        {
            label2.Visible = true;
            if (File.Exists(Application.StartupPath + @"\OpenWebKitSharp.dll") == false)
            {
                label3.Visible = true;
                passtime.Stop();
                MessageBox.Show("MantouWeb360 is not installed correctly! Please reinstall latest version.");
                Application.Exit();
                
            }
            else
            {
                welcome pass = new welcome();
                pass.Show();
                this.Hide();
                passtime.Stop();
            }

        }
    }
}
