using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace MantouWeb360
{
    
    static class Program
    {

        [STAThread]

        static void Main()
        {
            
            ThreadExceptionHandler handler = new ThreadExceptionHandler();

            Application.ThreadException +=
                new ThreadExceptionEventHandler(handler.Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            
            try
            {
                Uri intCheck = new Uri("http://google.com");
                HttpWebRequest requestint = (HttpWebRequest)WebRequest.Create(intCheck);
                HttpWebResponse responseint;
                
                if (File.Exists("C:\\MantouWeb360\\exitupdate.mwp") == false)
                {
                    Uri urlCheck = new Uri("http://mantoudev.cincout.net/360ver/SE-v4.1.0.update");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
                    //request.Timeout = 15000;
                    HttpWebResponse response;
                    try
                    {
                        responseint = (HttpWebResponse)requestint.GetResponse();
                        try
                        {
                            response = (HttpWebResponse)request.GetResponse();
                            if (File.Exists("C:\\MantouWeb360\\firstrun.mwp"))
                            {
                                try
                                {
                                    Application.Run(new mainForm());
                                }
                                catch (System.Exception ex)
                                {
                                  
                                        MessageBox.Show("MantouWeb360 has crashed. If problems persist please contact MantouDev support");
                                }

                            }
                            else
                            {
                                System.IO.Directory.CreateDirectory("C:\\MantouWeb360");
                                Application.Run(new loadScreenForm());
                            }


                        }
                        catch (Exception)
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + @"\mw360launcher.exe");
                            Application.Exit();

                        }
                    }
                    catch
                    {
                        MessageBox.Show("You are not connected to the internet. Please check your network connection.");
                        Application.Run(new mainForm());
                    }
                }
                else
                {
                    if (File.Exists("C:\\MantouWeb360\\firstrun.mwp"))
                    {
                        Application.Run(new mainForm());
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory("C:\\MantouWeb360");
                        Application.Run(new loadScreenForm());
                    }
                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("MantouWeb360 Has Crashed. If problems persist please contact MantouDev support");
            }
            





            
        }
    }
    internal class ThreadExceptionHandler
    {
        /// 
        /// Handles the thread exception.
        /// 
        public void Application_ThreadException(
            object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                MessageBox.Show("MantouWeb360 Has Crashed. If problems persist please contact MantouDev support");
                
            }
            catch
            {
                // Fatal error, terminate program
                try
                {
                    MessageBox.Show("Fatal Error Occur!",
                        "Fatal Error Occur!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /// 
        /// Creates and displays the error message.
        /// 
        private DialogResult ShowThreadExceptionDialog(Exception ex)
        {
            string errorMessage =
                "Unhandled Exception:\n\n" +
                ex.Message + "\n\n" +
                ex.GetType() +
                "\n\nStack Trace:\n" +
                ex.StackTrace;

            return MessageBox.Show(errorMessage,
                "Application Error",
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
    } 
}
