
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
            this.btnCredit = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.linkLH = new System.Windows.Forms.LinkLabel();
            this.linkVHG = new System.Windows.Forms.LinkLabel();
            this.labelLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGameLocation
            // 
            this.btnGameLocation.Location = new System.Drawing.Point(12, 30);
            this.btnGameLocation.Name = "btnGameLocation";
            this.btnGameLocation.Size = new System.Drawing.Size(75, 23);
            this.btnGameLocation.TabIndex = 0;
            this.btnGameLocation.Text = "Chọn";
            this.btnGameLocation.UseVisualStyleBackColor = true;
            this.btnGameLocation.Click += new System.EventHandler(this.btnGameLocation_Click);
            // 
            // textBoxGameLocation
            // 
            this.textBoxGameLocation.Location = new System.Drawing.Point(93, 33);
            this.textBoxGameLocation.Name = "textBoxGameLocation";
            this.textBoxGameLocation.ReadOnly = true;
            this.textBoxGameLocation.Size = new System.Drawing.Size(329, 20);
            this.textBoxGameLocation.TabIndex = 1;
            this.textBoxGameLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxGameLocation_DragDrop);
            this.textBoxGameLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxGameLocation_DragEnter);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 65);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(202, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 99);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(410, 28);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Cài đặt";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(220, 65);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(202, 28);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "Gỡ cài đặt";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.Location = new System.Drawing.Point(12, 404);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(410, 23);
            this.btnCredit.TabIndex = 5;
            this.btnCredit.Text = "Thông tin / Thực hiện";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 133);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(410, 10);
            this.progressBar.TabIndex = 6;
            // 
            // listBoxLog
            // 
            this.listBoxLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 154);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(410, 238);
            this.listBoxLog.TabIndex = 7;
            this.listBoxLog.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxLog_DrawItem);
            this.listBoxLog.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBoxLog_MeasureItem);
            // 
            // linkLH
            // 
            this.linkLH.AutoSize = true;
            this.linkLH.Location = new System.Drawing.Point(12, 436);
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
            this.linkVHG.Location = new System.Drawing.Point(343, 436);
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
            this.labelLocation.Location = new System.Drawing.Point(12, 14);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(80, 13);
            this.labelLocation.TabIndex = 10;
            this.labelLocation.Text = "Thư mục Game";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.linkVHG);
            this.Controls.Add(this.linkLH);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.textBoxGameLocation);
            this.Controls.Add(this.btnGameLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 500);
            this.MinimumSize = new System.Drawing.Size(450, 500);
            this.Name = "MainUI";
            this.Text = "NieR Replicant™ ver.1.22474487139... Việt Hóa";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Shown += new System.EventHandler(this.MainUI_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGameLocation;
        private System.Windows.Forms.TextBox textBoxGameLocation;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.LinkLabel linkLH;
        private System.Windows.Forms.LinkLabel linkVHG;
        private System.Windows.Forms.Label labelLocation;
    }
}

