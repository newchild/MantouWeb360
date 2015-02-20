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
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Ionic;
using Ionic.Zlib;
using Ionic.Crc;
using Ionic.BZip2;
using Ionic.Zip;
using IWshRuntimeLibrary;


namespace mw360launcher
{

    public partial class zhForm1 : Form
    {



        public zhForm1()
        {
            InitializeComponent();
        }

        private void launcherForm_Load(object sender, EventArgs e)
        {

        }


        private void downloader_DoWork(object sender, DoWorkEventArgs e)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360");
            string sUrlToReadFileFrom = "http://mantoudev.cincout.net/360ver/corefiles.zip";
            string sFilePathToWriteFileTo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\corefiles.zip";

            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            Int64 iSize = response.ContentLength;
            Int64 iRunningByteTotal = 0;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            downloader.ReportProgress(iProgressPercentage);
                        }
                        streamLocal.Close();
                    }

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
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://mantoudev.cincout.net/360ver/Ionic.Zip.dll", Application.StartupPath + @"\\Ionic.Zip.dll");
            downloaderexe.RunWorkerAsync();

        }

        private void install_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360"))
            {
                MessageBox.Show("馒头WEB360已安装。如果你想重新安装，请先卸载。");
            }
            else
            {
                downloader.RunWorkerAsync();
                label1.Show();
                dlprogress.Show();
                label2.Hide();
                install.Enabled = false;
                uninstall.Enabled = false;
            }

        }

        private void downloaderexe_DoWork(object sender, DoWorkEventArgs e)
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360");
            string sUrlToReadFileFrom = "http://mantoudev.cincout.net/360ver/latestversionzh.exe";
            string sFilePathToWriteFileTo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\MantouWeb360.exe";
            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            Int64 iSize = response.ContentLength;

            Int64 iRunningByteTotal = 0;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            downloaderexe.ReportProgress(iProgressPercentage);
                        }

                        streamLocal.Close();
                    }

                    streamRemote.Close();
                }
            }
        }

        private void downloaderexe_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dlprogress.Value = e.ProgressPercentage;
        }

        private void downloaderexe_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://mantoudev.cincout.net/360ver/mw360launcher.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\mw360launcher.exe");
            webClient.DownloadFile("http://mantoudev.cincout.net/360ver/BrowserDoctorHelper.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\BrowserDoctorHelper.exe");
            dlloader.RunWorkerAsync();
        }

        private void extract_DoWork(object sender, DoWorkEventArgs e)
        {

            ZipFile zipFile = new ZipFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\corefiles.zip");
            zipFile.ExtractAll(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360");
        }

        private void extract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var wsh = new IWshShell_Class();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MantouWeb360.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\MantouWeb360.exe";
            shortcut.Save();

            var wsh2 = new IWshShell_Class();
            IWshRuntimeLibrary.IWshShortcut shortcut2 = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\MantouWeb360.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut2.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360\\MantouWeb360.exe";
            shortcut2.Save();

            var wsh3 = new IWshShell_Class();
            IWshRuntimeLibrary.IWshShortcut shortcut3 = wsh.CreateShortcut(
                   Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\Uninstall MantouWeb360.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut3.TargetPath = "C:\\MantouDev\\installer.exe";
            shortcut3.Save();

            extractload.Hide();
            elabel.Hide();
            MessageBox.Show("馒头WEB360已成功安装");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("卸载馒头WEB360？", "卸载", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\MantouWeb360", true);
                Directory.Delete("C:\\MantouWeb360", true);
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MantouWeb360.lnk");
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\MantouWeb360.lnk");
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\Uninstall MantouWeb360.lnk");
                MessageBox.Show("馒头WEB360卸装成功");
                Application.Exit();


            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void dlloader_DoWork(object sender, DoWorkEventArgs e)
        {
            Directory.CreateDirectory("C:\\MantouDev");
            string sUrlToReadFileFrom = "http://mantoudev.cincout.net/360ver/installer.exe";
            string sFilePathToWriteFileTo = "C:\\MantouDev\\installer.exe";
            Uri url = new Uri(sUrlToReadFileFrom);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            response.Close();
            Int64 iSize = response.ContentLength;

            Int64 iRunningByteTotal = 0;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                {
                    using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];
                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRunningByteTotal += iByteSize;

                            double dIndex = (double)(iRunningByteTotal);
                            double dTotal = (double)byteBuffer.Length;
                            double dProgressPercentage = (dIndex / dTotal);
                            int iProgressPercentage = (int)(dProgressPercentage * 100);

                            dlloader.ReportProgress(iProgressPercentage);
                        }

                        streamLocal.Close();
                    }

                    streamRemote.Close();
                }
            }
        }

        private void dlloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            extract.RunWorkerAsync();
            elabel.Show();
            dlprogress.Hide();
            label1.Hide();
            extractload.Show();
        }

        private void dlloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dlprogress.Value = e.ProgressPercentage;
        }

        private void uninstall_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = redstore._360mascotsad;
        }

        private void uninstall_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = redstore._360mascotalt;
        }

        private void install_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = redstore._360mascot;
        }

        private void install_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = redstore._360mascotalt;
        }

        private void zhForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
