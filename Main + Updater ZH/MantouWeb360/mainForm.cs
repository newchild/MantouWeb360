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
using System.Threading;
using WebKit.DOM;
using WebKit;
using WebKit.Interop;
using Microsoft.VisualBasic;
using System.Diagnostics;


namespace MantouWeb360
{
    public partial class mainForm : Form
    {
        public string StringA { get; set; }
        [Flags]
        enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }
        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);


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

        
        public mainForm()
        {
            
            InitializeComponent();
            webView.Navigate("http://baidu.com");
            webView.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/537.71 (KHTML, like Gecko) Version/7.0 Safari/537.71";
            filler.Text = string.Empty;
            if(File.Exists("C:\\MantouWeb360\\firstrun.mwp") == false)
            {
                File.WriteAllText("C:\\MantouWeb360\\firstrun.mwp", "welcome = false");
            }
            if(File.Exists("C:\\MantouWeb360\\exitupdate.mwp"))
            {
                File.Delete("C:\\MantouWeb360\\exitupdate.mwp");
            }
            if (File.Exists("C:\\MantouWeb360\\404.html") == false)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://mantoudev.cincout.net/360ver/404.html", @"C:/MantouWeb360/404.html");
            }
            if (File.Exists(Application.StartupPath + @"\BrowserDoctorHelper.exe") == false)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://mantoudev.cincout.net/360ver/BrowserDoctorHelper.exe", Application.StartupPath + @"\BrowserDoctorHelper.exe");
            }
        }

        private void urlBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               webView.Navigate(urlBar.Text);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            gbox.Image = resStore.du;
            searchcheck.Checked = true;
            searchBar.Text = "百度搜索...";
            //preferences are not retained on browser restart, these are here for stability
            webView.AllowCookies = true;
            webView.Preferences.UseCache = true;
        }


        private void zin_ButtonClick(object sender, EventArgs e)
        {
            webView.IncreaseZoom();
            this.ActiveControl = null;
        }

        private void zout_ButtonClick(object sender, EventArgs e)
        {
            webView.DecreaseZoom();
            this.ActiveControl = null;
        }

        private void webView_ProgressChanged(object sender, WebKit.ProgressChangesEventArgs e)
        {
            progBar.Value = e.Percent;
        }

        private void webView_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            urlBar.Text = webView.Url.ToString();
            loading.Image = resStore.forwardsloader;
            connect.Visible = false;

        }

        private void webView_FaviconAvaiable(object sender, WebKit.FaviconAvailableEventArgs e)
        {
            if (e.Favicon != null)
            {
                favicon.Visible = true;
                favicon.Image = e.Favicon.ToBitmap();
            }

        }

        private void urlBar_Click(object sender, EventArgs e)
        {
            AcceptButton = go;
        }

        private void go_Click(object sender, EventArgs e)
        {
            webView.Navigate(urlBar.Text);
            connect.Visible = true;
            AcceptButton = null;
            this.ActiveControl = null;
            
        }

        private void webView_Navigating(object sender, WebKit.WebKitBrowserNavigatingEventArgs e)
        {
            loading.Image = resStore.reverseloader;
            connect.Visible = true;
            loading.Visible = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            webView.GoBack();
            this.ActiveControl = null;
        }

        private void forward_Click(object sender, EventArgs e)
        {
            webView.GoForward();
            this.ActiveControl = null;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            webView.Reload();
            this.ActiveControl = null;
        }

        private void home_Click(object sender, EventArgs e)
        {
            webView.Navigate("http://google.com");
            this.ActiveControl = null;
        }

        private void fullscreen_ButtonClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if(this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fullscrn.Text = "全屏：在";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                fullscrn.Text = "全屏：关闭";
            }
        }

        private void downloads_ButtonClick(object sender, EventArgs e)
        {
            webView.ShowDownloader();
        }

        private void stimer_Tick(object sender, EventArgs e)
        {
            statustext.Text = webView.StatusText;
            
        }

        private void report_ButtonClick(object sender, EventArgs e)
        {
            webView.Navigate("http://mantoudev.uk.to/360bugreport");
        }

        private void webView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            title.Text = webView.DocumentTitle;
            loading.Image = resStore.forwardsloader;
            loading.Visible = false;
        }

        private void menu_Click(object sender, EventArgs e)
        {
            
            this.ActiveControl = null;
            if (menuPanel.Visible == false)
            {
                if (uapane.Visible == true)
                {
                    Util.Animate(uapane, Util.Effect.Slide, 150, 180);
                    uapane.Hide();
                    menuPanel.Hide();
                }
                if (bd.Visible == true)
                {
                    Util.Animate(bd, Util.Effect.Slide, 150, 180);
                    bd.Hide();
                    menuPanel.Hide();
                }
                if (prefPane.Visible == true)
                {
                    Util.Animate(prefPane, Util.Effect.Slide, 150, 180);
                    prefPane.Hide();
                    menuPanel.Hide();
                }
                else
                {
                    Util.Animate(menuPanel, Util.Effect.Slide, 150, 90);
                    menuPanel.Show();
                    menuPanel.Refresh();
                }
            }
            else
            {
                if (uapane.Visible == true)
                {
                    Util.Animate(uapane, Util.Effect.Slide, 150, 180);
                    uapane.Hide();
                }
                Util.Animate(menuPanel, Util.Effect.Slide, 150, 90);
                menuPanel.Hide();
                menuPanel.Refresh();
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            Application.Exit();
        }

        private void webView_Error(object sender, WebKit.WebKitBrowserErrorEventArgs e)
        {
            webView.OpenDocument(@"C:/MantouWeb360/404.html");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            AcceptButton = null;
            if(searchcheck.Checked == false)
            {
                webView.Url = new Uri("http://www.google.com/search?q=" + searchBar.Text);
            }
            if (searchcheck.Checked == true)
            {
                webView.Url = new Uri("http://www.baidu.com/s?i&wd=" + searchBar.Text);
            }
        }

        private void searchBar_Click(object sender, EventArgs e)
        {
            AcceptButton = searchBtn;
            if (searchBar.Text == "谷歌搜索...")
            {
                searchBar.Text = null;
            }
            if (searchBar.Text == "百度搜索...")
            {
                searchBar.Text = null;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            webView.ShowSaveAsDialog();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void open_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            using (OpenFileDialog opn = new OpenFileDialog())
            {

                if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    webView.OpenDocument(opn.FileName);
                }
            }
        }

        private void pbrowse_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if(webView.PrivateBrowsing == false)
            {
                webView.PrivateBrowsing = true;
                pbrowse.Text = "私人浏览：在";
                pb.Show();

            }
            else
            {
                webView.PrivateBrowsing = false;
                pbrowse.Text = "私人浏览：关";
                pb.Hide();
            }
        }

        private void fullscrn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fullscrn.Text = "全屏：在";
                menuPanel.Hide();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                fullscrn.Text = "全屏：关闭";
                menuPanel.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            webView.IncreaseZoom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            webView.DecreaseZoom();
        }

        private void fontshade_Click(object sender, EventArgs e)
        {
            if(webView.Preferences.UseFontSmoothing == false)
            {
                webView.Preferences.UseFontSmoothing = true;
            }
            else
            {
                webView.Preferences.UseFontSmoothing = false;
            }
           
             
        }

        private void dl_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            webView.ShowDownloader();
        }

        private void inspector_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            webView.ShowInspector();
        }

        private void source_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            webView.GetSourceCode();
        }

        private void about_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            about pass = new about();
            pass.Show();
        }

        private void help_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            help pass = new help();
            pass.Show();
        }

        private void usragent_Click(object sender, EventArgs e)
        {
            Util.Animate(uapane, Util.Effect.Slide, 150, 90);
            uapane.Show();
            //menuPanel.Hide();
        }

        private void setua_Click(object sender, EventArgs e)
        {
            if (uabox.Text == "Safari浏览器（默认）")
            {
                webView.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/537.71 (KHTML, like Gecko) Version/7.0 Safari/537.71";
                webView.Reload();
                Util.Animate(uapane, Util.Effect.Slide, 150, 90);
                uapane.Hide();
            }
            if(uabox.Text == "馒头WEB360")
            {
                webView.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/537.71 (KHTML, like Gecko) Version/3.0 MantouWeb/537.71";
                webView.Reload();
                Util.Animate(uapane, Util.Effect.Slide, 150, 90);
                uapane.Hide();
            }
            if (uabox.Text == "互联网浏览器")
            {
                webView.UserAgent = "Mozilla/5.0 (Windows; U; MSIE 11.0; WIndows NT 9.0; en-US))";
                webView.Reload();
                Util.Animate(uapane, Util.Effect.Slide, 150, 90);
                uapane.Hide();
            }
            if(uabox.Text == "Gecko")
            {
                webView.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0";
                webView.Reload();
                Util.Animate(uapane, Util.Effect.Slide, 150, 90);
                uapane.Hide();
            }
            if (uabox.Text == "移动")
            {
                webView.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30";
                webView.Reload();
                Util.Animate(uapane, Util.Effect.Slide, 150, 90);
                uapane.Hide();
            }
            if (uabox.Text == "自定义字符串")
            {
                webView.UserAgent = uastringbox.Text;
                webView.Reload();
                uapane.Hide();
                uastringbox.Hide();
                uastring.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uastring.Hide();
            uastringbox.Show();
            uabox.Text = "自定义字符串";

        }

        

        private void gbox_Click(object sender, EventArgs e)
        {
            if(searchcheck.Checked == false)
            {
                gbox.Image = resStore.du;
                searchcheck.Checked = true;
                searchBar.Text = "百度搜索...";
            }
            else
            {
                gbox.Image = resStore.google;
                searchcheck.Checked = false;
                searchBar.Text = "谷歌搜索...";
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = resStore.cornershadpress;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = resStore.cornershad;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = resStore.cornershadpress2;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = resStore.cornershad2;
        }

        private void mainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void preflistener_Tick(object sender, EventArgs e)
        {
            
        }

        private void webView_ShowJavaScriptPromptBeforeUnload(object sender, ShowJavaScriptPromptBeforeUnloadEventArgs e)
        {

            if (MessageBox.Show(e.Message, "MantouWeb360 SE", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                e.ReturnValue = true;
            }
            else
            {
                e.ReturnValue = false;
            }
        }

        private void webView_ShowJavaScriptConfirmPanel(object sender, WebKit.ShowJavaScriptConfirmPanelEventArgs e)
        {
            bool val = (MessageBox.Show(e.Message, "MantouWeb360 SE", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
            e.ReturnValue = val;
        }

        private void webView_ShowJavaScriptPromptPanel(object sender, WebKit.ShowJavaScriptPromptPanelEventArgs e)
        {
            e.ReturnValue = Microsoft.VisualBasic.Interaction.InputBox(e.Message, "", e.DefaultValue);
        }

        private void webView_ShowJavaScriptAlertPanel(object sender, WebKit.ShowJavaScriptAlertPanelEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void closeprefs_Click(object sender, EventArgs e)
        {
            if (uapane.Visible == true)
            {
                Util.Animate(uapane, Util.Effect.Slide, 150, 180);
                uapane.Hide();
            }
            if (bd.Visible == true)
            {
                Util.Animate(bd, Util.Effect.Slide, 150, 180);
                bd.Hide();
            }
            Util.Animate(prefPane, Util.Effect.Slide, 150, 180);
            prefPane.Hide();
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 90);
            menuPanel.Show();
            menuPanel.Refresh();
        }

        private void pref_Click(object sender, EventArgs e)
        {
            Util.Animate(menuPanel, Util.Effect.Slide, 150, 90);
            menuPanel.Hide();
            Util.Animate(prefPane, Util.Effect.Slide, 150, 180);
            prefPane.Show();
            prefPane.Refresh();

            //Preferences Update
            

        }

        private void cookiescheck_CheckedChanged(object sender, EventArgs e)
        {
            if(webView.AllowCookies == true)
            {
                webView.AllowCookies = false;
        
            }
            else
            {
                webView.AllowCookies = true;

            }


        }

        private void usecache_CheckedChanged(object sender, EventArgs e)
        {
            if(webView.Preferences.UseCache == true)
            {
                webView.Preferences.UseCache = false;
            }
            else
            {
                webView.Preferences.UseCache = true;
            }
        }

        private void allowplug_CheckedChanged(object sender, EventArgs e)
        {
            if (webView.Preferences.AllowPlugins == true)
            {
                webView.Preferences.AllowPlugins = false;
            }
            else
            {
                webView.Preferences.AllowPlugins = true;
            }
        }

        private void close_diags_Click(object sender, EventArgs e)
        {
            Util.Animate(bd, Util.Effect.Slide, 150, 180);
            bd.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("好了，重新启动浏览器引擎");
            Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
            webView.Refresh();
            diag_timer.Start();
        }

        private void diag_timer_Tick(object sender, EventArgs e)
        {
            
            diag_timer.Stop();
            DialogResult dialogResult = MessageBox.Show("在问题指定的固定？", "Browser Doctor", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("太好了！快乐浏览！");
                bd.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                DialogResult dialogResult2 = MessageBox.Show("好吧，馒头Web360将重新启动。如果问题仍然存在，请联系馒头软件或提交错误报告。你想重新启动馒头Web360？", "Browser Doctor", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    bd.Hide();
                }
            }
        }

        private void diags_Click(object sender, EventArgs e)
        {
            Util.Animate(bd, Util.Effect.Slide, 150, 180);
            bd.Show();
            bd.Refresh();
        }

        private void blurry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("好吧，字体平滑将被关闭");
            Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
            webView.Preferences.UseFontSmoothing = false;
            diag_timer.Start();
        }

        private void plugfail_Click(object sender, EventArgs e)
        {
            if (webView.Preferences.AllowPlugins == true)
            {
                MessageBox.Show("插件被启用。请更新或重新安装你使用任何插件，这可能会解决这个问题。");
                DialogResult dialogResult2 = MessageBox.Show("你想重新启动馒头Web360？这可能会解决任何插件问题", "Browser Doctor", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {

                    Application.Restart();
                }
                else
                {
                    //do nothing
                }
            }
            else
            {
                MessageBox.Show("插件在首选项被禁用。它们现在将接通");
                DialogResult dialogResult2 = MessageBox.Show("刷新页面？", "Browser Doctor", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
                    webView.Reload();
                    diag_timer.Start();
                }
                else
                {
                    Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
                    diag_timer.Start();
                    //do nothing
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("好吧，兼容性模式将被打开");
            Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
            webView.UserAgent = "Mozilla/5.0 (Windows; U; MSIE 11.0; WIndows NT 9.0; en-US))";
            webView.Reload();
            diag_timer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("好吧，馒头Web360将重新启动。你想继续吗？", "Browser Doctor", MessageBoxButtons.YesNo);
            if (dialogResult2 == DialogResult.Yes)
            {
                Process.Start(Application.StartupPath + @"\BrowserDoctorHelper.exe");
                Application.Restart();
            }
            else
            {
                bd.Hide();
                //do nothing
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (webView.UseJavaScript == true)
            {
                webView.UseJavaScript = false;
            }
            else
            {
                webView.UseJavaScript = true;
            }
        }

        private void inibutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opn = new OpenFileDialog())
            {
                opn.Filter = "INI Files (*.ini)|*.ini";
                opn.InitialDirectory = Application.StartupPath + @"\LanguageLoader.resources";
                if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    WebKit.LanguageLoader.SetLanguageFromINIFile(opn.FileName);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                this.Opacity = 0.75;
            }
            else
            {
                this.Opacity = 1;
            }
        }

        private void ccookies_Click(object sender, EventArgs e)
        {
            DialogResult result2 = MessageBox.Show("清除Cookies？", "Clear cookies?", MessageBoxButtons.YesNo);
            if (result2 == DialogResult.Yes)
            {
                File.Delete(Environment.ExpandEnvironmentVariables("%APPDATA%\\Apple Computer\\Cookies\\Cookies.binarycookies"));
                MessageBox.Show("Cookies cleared successfully!");
            }
        }

        private void webView_Load(object sender, EventArgs e)
        {

        }




    }
}