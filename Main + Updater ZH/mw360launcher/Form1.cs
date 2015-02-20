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
using System.Net;

namespace mw360launcher
{
    public partial class launcherForm : Form
    {
        public launcherForm()
        {
            InitializeComponent();
        }

        private void launcherForm_Load(object sender, EventArgs e)
        {
            
        }

        private void noUpdate_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\MantouWeb360\\exitupdate.mwp", "exit updater");
            System.Diagnostics.Process.Start(Application.StartupPath + @"\MantouWeb360.exe");
            Application.Exit();
        }

        private void yesUpdate_Click(object sender, EventArgs e)
        {
            downloader.RunWorkerAsync();
            changelogBrowser.Visible = false;
            dlprogress.Visible = true;
            label1.Visible = true;
        }

        private void downloader_DoWork(object sender, DoWorkEventArgs e)
        {
            // the URL to download the file from
            string sUrlToReadFileFrom = "http://mantoudev.cincout.net/360ver/latestversion.exe";
            // the path to write the file to
            string sFilePathToWriteFileTo = Application.StartupPath + @"\MantouWeb360.exe";

            // first, we need to get the exact size (in bytes) of the file we are downloading
            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            // gets the size of the file in bytes
            Int64 iSize = response.ContentLength;

            // keeps track of the total bytes downloaded so we can update the progress bar
            Int64 iRunningByteTotal = 0;

            // use the webclient object to download the file
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                // open the file at the remote URL for reading
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    // using the FileStream object, we can write the downloaded bytes to the file system
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // loop the stream and get the file into the byte buffer
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            // write the bytes to the file system at the file path specified
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            // calculate the progress out of a base "100"
                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            // update the progress bar
                            downloader.ReportProgress(iProgressPercentage);
                        }

                        // clean up the file stream
                        streamLocal.Close();
                    }

                    // close the connection to the remote server
                    streamRemote.Close();
                }
            }
        }

        private void downloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dlprogress.Value = e.ProgressPercentage;
        }

        private void downloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("MantouWeb360 has been updated successfully");
            System.Diagnostics.Process.Start(Application.StartupPath + @"\MantouWeb360.exe");
            Application.Exit();
        }
    }
}
