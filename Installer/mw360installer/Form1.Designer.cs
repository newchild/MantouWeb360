namespace mw360launcher
{
    partial class zhlauncherform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zhlauncherform));
            this.install = new System.Windows.Forms.Button();
            this.downloader = new System.ComponentModel.BackgroundWorker();
            this.dlprogress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.downloaderexe = new System.ComponentModel.BackgroundWorker();
            this.extractload = new System.Windows.Forms.PictureBox();
            this.elabel = new System.Windows.Forms.Label();
            this.extract = new System.ComponentModel.BackgroundWorker();
            this.uninstall = new System.Windows.Forms.Button();
            this.dlloader = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractload)).BeginInit();
            this.SuspendLayout();
            // 
            // install
            // 
            this.install.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.install.BackColor = System.Drawing.Color.White;
            this.install.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.install.FlatAppearance.BorderSize = 2;
            this.install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.install.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install.ForeColor = System.Drawing.Color.ForestGreen;
            this.install.Location = new System.Drawing.Point(12, 396);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(232, 53);
            this.install.TabIndex = 2;
            this.install.Text = "Install MantouWeb360";
            this.install.UseVisualStyleBackColor = false;
            this.install.Click += new System.EventHandler(this.install_Click);
            this.install.MouseEnter += new System.EventHandler(this.install_MouseEnter);
            this.install.MouseLeave += new System.EventHandler(this.install_MouseLeave);
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
            this.dlprogress.Location = new System.Drawing.Point(12, 263);
            this.dlprogress.Name = "dlprogress";
            this.dlprogress.Size = new System.Drawing.Size(311, 23);
            this.dlprogress.TabIndex = 3;
            this.dlprogress.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Downloading MantouWeb...";
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::mw360launcher.redstore._360mascotalt;
            this.pictureBox2.Location = new System.Drawing.Point(329, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 229);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Please choose an option";
            // 
            // downloaderexe
            // 
            this.downloaderexe.WorkerReportsProgress = true;
            this.downloaderexe.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloaderexe_DoWork);
            this.downloaderexe.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.downloaderexe_ProgressChanged);
            this.downloaderexe.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.downloaderexe_RunWorkerCompleted);
            // 
            // extractload
            // 
            this.extractload.Image = ((System.Drawing.Image)(resources.GetObject("extractload.Image")));
            this.extractload.Location = new System.Drawing.Point(12, 263);
            this.extractload.Name = "extractload";
            this.extractload.Size = new System.Drawing.Size(311, 31);
            this.extractload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.extractload.TabIndex = 8;
            this.extractload.TabStop = false;
            this.extractload.Visible = false;
            // 
            // elabel
            // 
            this.elabel.AutoSize = true;
            this.elabel.Location = new System.Drawing.Point(147, 234);
            this.elabel.Name = "elabel";
            this.elabel.Size = new System.Drawing.Size(57, 13);
            this.elabel.TabIndex = 9;
            this.elabel.Text = "Installing...";
            this.elabel.Visible = false;
            // 
            // extract
            // 
            this.extract.DoWork += new System.ComponentModel.DoWorkEventHandler(this.extract_DoWork);
            this.extract.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.extract_RunWorkerCompleted);
            // 
            // uninstall
            // 
            this.uninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uninstall.BackColor = System.Drawing.Color.White;
            this.uninstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uninstall.FlatAppearance.BorderSize = 2;
            this.uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstall.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstall.ForeColor = System.Drawing.Color.ForestGreen;
            this.uninstall.Location = new System.Drawing.Point(250, 396);
            this.uninstall.Name = "uninstall";
            this.uninstall.Size = new System.Drawing.Size(222, 53);
            this.uninstall.TabIndex = 10;
            this.uninstall.Text = "Uninstall MantouWeb360";
            this.uninstall.UseVisualStyleBackColor = false;
            this.uninstall.Click += new System.EventHandler(this.button1_Click);
            this.uninstall.MouseEnter += new System.EventHandler(this.uninstall_MouseEnter);
            this.uninstall.MouseLeave += new System.EventHandler(this.uninstall_MouseLeave);
            // 
            // dlloader
            // 
            this.dlloader.WorkerReportsProgress = true;
            this.dlloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dlloader_DoWork);
            this.dlloader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dlloader_ProgressChanged);
            this.dlloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dlloader_RunWorkerCompleted);
            // 
            // zhlauncherform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.uninstall);
            this.Controls.Add(this.elabel);
            this.Controls.Add(this.extractload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dlprogress);
            this.Controls.Add(this.install);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "zhlauncherform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MantouWeb360";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.zhlauncherform_FormClosing);
            this.Load += new System.EventHandler(this.launcherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button install;
        private System.ComponentModel.BackgroundWorker downloader;
        private System.Windows.Forms.ProgressBar dlprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker downloaderexe;
        private System.Windows.Forms.PictureBox extractload;
        private System.Windows.Forms.Label elabel;
        private System.ComponentModel.BackgroundWorker extract;
        private System.Windows.Forms.Button uninstall;
        private System.ComponentModel.BackgroundWorker dlloader;

    }
}

