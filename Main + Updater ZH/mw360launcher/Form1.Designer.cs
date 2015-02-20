namespace mw360launcher
{
    partial class launcherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcherForm));
            this.changelogBrowser = new System.Windows.Forms.WebBrowser();
            this.noUpdate = new System.Windows.Forms.Button();
            this.yesUpdate = new System.Windows.Forms.Button();
            this.downloader = new System.ComponentModel.BackgroundWorker();
            this.dlprogress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changelogBrowser
            // 
            this.changelogBrowser.Location = new System.Drawing.Point(12, 12);
            this.changelogBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.changelogBrowser.Name = "changelogBrowser";
            this.changelogBrowser.Size = new System.Drawing.Size(460, 378);
            this.changelogBrowser.TabIndex = 0;
            this.changelogBrowser.Url = new System.Uri("http://mantoudev.cincout.net/360ver/latestchangelog.txt", System.UriKind.Absolute);
            // 
            // noUpdate
            // 
            this.noUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noUpdate.BackColor = System.Drawing.Color.White;
            this.noUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noUpdate.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.noUpdate.FlatAppearance.BorderSize = 2;
            this.noUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noUpdate.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noUpdate.ForeColor = System.Drawing.Color.ForestGreen;
            this.noUpdate.Location = new System.Drawing.Point(244, 396);
            this.noUpdate.Name = "noUpdate";
            this.noUpdate.Size = new System.Drawing.Size(228, 53);
            this.noUpdate.TabIndex = 1;
            this.noUpdate.Text = "Don\'t Update";
            this.noUpdate.UseVisualStyleBackColor = false;
            this.noUpdate.Click += new System.EventHandler(this.noUpdate_Click);
            // 
            // yesUpdate
            // 
            this.yesUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yesUpdate.BackColor = System.Drawing.Color.White;
            this.yesUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yesUpdate.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.yesUpdate.FlatAppearance.BorderSize = 2;
            this.yesUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesUpdate.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesUpdate.ForeColor = System.Drawing.Color.ForestGreen;
            this.yesUpdate.Location = new System.Drawing.Point(12, 396);
            this.yesUpdate.Name = "yesUpdate";
            this.yesUpdate.Size = new System.Drawing.Size(226, 53);
            this.yesUpdate.TabIndex = 2;
            this.yesUpdate.Text = "Install Update";
            this.yesUpdate.UseVisualStyleBackColor = false;
            this.yesUpdate.Click += new System.EventHandler(this.yesUpdate_Click);
            // 
            // downloader
            // 
            this.downloader.WorkerReportsProgress = true;
            this.downloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloader_DoWork);
            this.downloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloader_ProgressChanged);
            this.downloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloader_RunWorkerCompleted);
            // 
            // dlprogress
            // 
            this.dlprogress.Location = new System.Drawing.Point(12, 191);
            this.dlprogress.Name = "dlprogress";
            this.dlprogress.Size = new System.Drawing.Size(460, 23);
            this.dlprogress.TabIndex = 3;
            this.dlprogress.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Downloading Update...";
            this.label1.Visible = false;
            // 
            // launcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dlprogress);
            this.Controls.Add(this.yesUpdate);
            this.Controls.Add(this.noUpdate);
            this.Controls.Add(this.changelogBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "launcherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MantouWeb360 Launcher v1.0";
            this.Load += new System.EventHandler(this.launcherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser changelogBrowser;
        private System.Windows.Forms.Button noUpdate;
        private System.Windows.Forms.Button yesUpdate;
        private System.ComponentModel.BackgroundWorker downloader;
        private System.Windows.Forms.ProgressBar dlprogress;
        private System.Windows.Forms.Label label1;

    }
}

