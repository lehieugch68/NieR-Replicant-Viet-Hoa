
namespace NieR_Replicant_Viet_Hoa
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.btnGameLocation = new System.Windows.Forms.Button();
            this.textBoxGameLocation = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.linkLH = new System.Windows.Forms.LinkLabel();
            this.linkVHG = new System.Windows.Forms.LinkLabel();
            this.labelLocation = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxFlag = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGameLocation
            // 
            this.btnGameLocation.Location = new System.Drawing.Point(12, 54);
            this.btnGameLocation.Name = "btnGameLocation";
            this.btnGameLocation.Size = new System.Drawing.Size(75, 23);
            this.btnGameLocation.TabIndex = 0;
            this.btnGameLocation.Text = "Select";
            this.btnGameLocation.UseVisualStyleBackColor = true;
            this.btnGameLocation.Click += new System.EventHandler(this.btnGameLocation_Click);
            // 
            // textBoxGameLocation
            // 
            this.textBoxGameLocation.Location = new System.Drawing.Point(93, 57);
            this.textBoxGameLocation.Name = "textBoxGameLocation";
            this.textBoxGameLocation.ReadOnly = true;
            this.textBoxGameLocation.Size = new System.Drawing.Size(329, 20);
            this.textBoxGameLocation.TabIndex = 1;
            this.textBoxGameLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxGameLocation_DragDrop);
            this.textBoxGameLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxGameLocation_DragEnter);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 89);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(202, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 123);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(410, 28);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(220, 89);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(202, 28);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 401);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(410, 10);
            this.progressBar.TabIndex = 6;
            // 
            // listBoxLog
            // 
            this.listBoxLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 157);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(410, 238);
            this.listBoxLog.TabIndex = 7;
            this.listBoxLog.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxLog_DrawItem);
            this.listBoxLog.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBoxLog_MeasureItem);
            // 
            // linkLH
            // 
            this.linkLH.AutoSize = true;
            this.linkLH.Location = new System.Drawing.Point(12, 434);
            this.linkLH.Name = "linkLH";
            this.linkLH.Size = new System.Drawing.Size(44, 13);
            this.linkLH.TabIndex = 8;
            this.linkLH.TabStop = true;
            this.linkLH.Text = "Lê Hiếu";
            this.linkLH.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLH_LinkClicked);
            // 
            // linkVHG
            // 
            this.linkVHG.AutoSize = true;
            this.linkVHG.Location = new System.Drawing.Point(343, 434);
            this.linkVHG.Name = "linkVHG";
            this.linkVHG.Size = new System.Drawing.Size(79, 13);
            this.linkVHG.TabIndex = 9;
            this.linkVHG.TabStop = true;
            this.linkVHG.Text = "Việt Hóa Game";
            this.linkVHG.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVHG_LinkClicked);
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(12, 38);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(79, 13);
            this.labelLocation.TabIndex = 10;
            this.labelLocation.Text = "Game Location";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(434, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "Menu";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // pictureBoxFlag
            // 
            this.pictureBoxFlag.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxFlag.Location = new System.Drawing.Point(362, 11);
            this.pictureBoxFlag.Name = "pictureBoxFlag";
            this.pictureBoxFlag.Size = new System.Drawing.Size(60, 40);
            this.pictureBoxFlag.TabIndex = 12;
            this.pictureBoxFlag.TabStop = false;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.pictureBoxFlag);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.linkVHG);
            this.Controls.Add(this.linkLH);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.textBoxGameLocation);
            this.Controls.Add(this.btnGameLocation);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 500);
            this.MinimumSize = new System.Drawing.Size(450, 500);
            this.Name = "MainUI";
            this.Text = "NieR Replicant™ ver.1.22474487139... Việt Hóa";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Shown += new System.EventHandler(this.MainUI_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGameLocation;
        private System.Windows.Forms.TextBox textBoxGameLocation;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.LinkLabel linkLH;
        private System.Windows.Forms.LinkLabel linkVHG;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxFlag;
    }
}

