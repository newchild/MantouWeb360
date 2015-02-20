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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace MantouWeb360
{
    public partial class welcome : Form
    {
        public static class Util
        {
            public enum Effect { Roll, Slide, Center, Blend }

            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];
                if (ctl.Visible) { flags |= 0x10000; angle += 180; }
                else
                {
                    if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                    else if (effect == Effect.Blend) throw new ArgumentException();
                }
                flags |= dirmap[(angle % 360) / 45];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok) throw new Exception("Animation failed");
                ctl.Visible = !ctl.Visible;
            }

            private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
            private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

            [DllImport("user32.dll")]
            private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
        }

        public welcome()
        {
            InitializeComponent();
            

            

        }

        private void closeWelcome_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm pass = new mainForm();
            pass.Show();
        }

        private void closeWelcome_MouseEnter(object sender, EventArgs e)
        {
            //closeWelcome.BackgroundImage = resStore.btnfinal2;
        }

        private void closeWelcome_MouseLeave(object sender, EventArgs e)
        {
            //closeWelcome.BackgroundImage = resStore.btnfinal3;
        }

        private void welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm pass = new mainForm();
            pass.Show();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            
        }

        private void next_Click(object sender, EventArgs e)
        {
            Util.Animate(wel, Util.Effect.Slide, 150, 360);
            Util.Animate(girl, Util.Effect.Slide, 150, 360);
            Util.Animate(stuff1, Util.Effect.Slide, 150, 360);
            Util.Animate(next, Util.Effect.Slide, 150, 360);
            Util.Animate(nextpane, Util.Effect.Slide, 150, 180);
            nextpane.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mantoudev.uk.to");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mantoudev.uk.to/mantouweb");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:support@mantoudev.uk.to");
        }

    }
}
