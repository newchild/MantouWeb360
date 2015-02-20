using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace mw360launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(Directory.Exists("C:\\MantouWeb360\\eng"))
            {
                Application.Run(new zhlauncherform());
            }
            if(Directory.Exists("C:\\MantouWeb360\\zh"))
            {
                Application.Run(new zhForm1());
            }
            if (Directory.Exists("C:\\MantouWeb360\\zh") == false && Directory.Exists("C:\\MantouWeb360\\eng") == false)
            {
                Application.Run(new start());
            }
            
        }
    }
}
