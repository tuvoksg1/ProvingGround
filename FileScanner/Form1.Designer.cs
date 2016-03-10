namespace FileScanner
{
    partial class Form1
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
            this.PatternTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RootBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.RootBtn = new System.Windows.Forms.Button();
            this.FolderTxt = new System.Windows.Forms.TextBox();
            this.ScanBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PatternTxt
            // 
            this.PatternTxt.Location = new System.Drawing.Point(105, 24);
            this.PatternTxt.Name = "PatternTxt";
            this.PatternTxt.Size = new System.Drawing.Size(444, 20);
            this.PatternTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Pattern";
            // 
            // RootBrowser
            // 
            this.RootBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // RootBtn
            // 
            this.RootBtn.Location = new System.Drawing.Point(24, 91);
            this.RootBtn.Name = "RootBtn";
            this.RootBtn.Size = new System.Drawing.Size(75, 23);
            this.RootBtn.TabIndex = 2;
            this.RootBtn.Text = "Root Folder...";
            this.RootBtn.UseVisualStyleBackColor = true;
            this.RootBtn.Click += new System.EventHandler(this.RootBtn_Click);
            // 
            // FolderTxt
            // 
            this.FolderTxt.Location = new System.Drawing.Point(105, 93);
            this.FolderTxt.Name = "FolderTxt";
            this.FolderTxt.Size = new System.Drawing.Size(444, 20);
            this.FolderTxt.TabIndex = 3;
            // 
            // ScanBtn
            // 
            this.ScanBtn.Location = new System.Drawing.Point(220, 187);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(150, 56);
            this.ScanBtn.TabIndex = 4;
            this.ScanBtn.Text = "Scan";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 365);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.FolderTxt);
            this.Controls.Add(this.RootBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PatternTxt);
            this.Name = "Form1";
            this.Text = "Folder Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PatternTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog RootBrowser;
        private System.Windows.Forms.Button RootBtn;
        private System.Windows.Forms.TextBox FolderTxt;
        private System.Windows.Forms.Button ScanBtn;
    }
}

