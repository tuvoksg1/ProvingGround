namespace Windows
{
    partial class TestHarness
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
            this.TestMenu = new System.Windows.Forms.TabControl();
            this.EnumerateTab = new System.Windows.Forms.TabPage();
            this.orderChk = new System.Windows.Forms.CheckBox();
            this.TreeOutputList = new System.Windows.Forms.ListBox();
            this.IterateBtn = new System.Windows.Forms.Button();
            this.SerializationTab = new System.Windows.Forms.TabPage();
            this.DeserializeBtn = new System.Windows.Forms.Button();
            this.SerializeBtn = new System.Windows.Forms.Button();
            this.TestMenu.SuspendLayout();
            this.EnumerateTab.SuspendLayout();
            this.SerializationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestMenu
            // 
            this.TestMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestMenu.Controls.Add(this.EnumerateTab);
            this.TestMenu.Controls.Add(this.SerializationTab);
            this.TestMenu.Location = new System.Drawing.Point(12, 12);
            this.TestMenu.Name = "TestMenu";
            this.TestMenu.SelectedIndex = 0;
            this.TestMenu.Size = new System.Drawing.Size(526, 500);
            this.TestMenu.TabIndex = 0;
            // 
            // EnumerateTab
            // 
            this.EnumerateTab.BackColor = System.Drawing.Color.LightGray;
            this.EnumerateTab.Controls.Add(this.orderChk);
            this.EnumerateTab.Controls.Add(this.TreeOutputList);
            this.EnumerateTab.Controls.Add(this.IterateBtn);
            this.EnumerateTab.Location = new System.Drawing.Point(4, 22);
            this.EnumerateTab.Name = "EnumerateTab";
            this.EnumerateTab.Padding = new System.Windows.Forms.Padding(3);
            this.EnumerateTab.Size = new System.Drawing.Size(518, 474);
            this.EnumerateTab.TabIndex = 0;
            this.EnumerateTab.Text = "Enumerate Tree";
            // 
            // orderChk
            // 
            this.orderChk.AutoSize = true;
            this.orderChk.Checked = true;
            this.orderChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.orderChk.Location = new System.Drawing.Point(116, 23);
            this.orderChk.Name = "orderChk";
            this.orderChk.Size = new System.Drawing.Size(79, 17);
            this.orderChk.TabIndex = 2;
            this.orderChk.Text = "Parent First";
            this.orderChk.UseVisualStyleBackColor = true;
            // 
            // TreeOutputList
            // 
            this.TreeOutputList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeOutputList.FormattingEnabled = true;
            this.TreeOutputList.Location = new System.Drawing.Point(23, 57);
            this.TreeOutputList.Name = "TreeOutputList";
            this.TreeOutputList.Size = new System.Drawing.Size(471, 381);
            this.TreeOutputList.TabIndex = 1;
            // 
            // IterateBtn
            // 
            this.IterateBtn.Location = new System.Drawing.Point(23, 19);
            this.IterateBtn.Name = "IterateBtn";
            this.IterateBtn.Size = new System.Drawing.Size(75, 23);
            this.IterateBtn.TabIndex = 0;
            this.IterateBtn.Text = "Iterate";
            this.IterateBtn.UseVisualStyleBackColor = true;
            this.IterateBtn.Click += new System.EventHandler(this.OnIterateClick);
            // 
            // SerializationTab
            // 
            this.SerializationTab.Controls.Add(this.DeserializeBtn);
            this.SerializationTab.Controls.Add(this.SerializeBtn);
            this.SerializationTab.Location = new System.Drawing.Point(4, 22);
            this.SerializationTab.Name = "SerializationTab";
            this.SerializationTab.Padding = new System.Windows.Forms.Padding(3);
            this.SerializationTab.Size = new System.Drawing.Size(518, 474);
            this.SerializationTab.TabIndex = 1;
            this.SerializationTab.Text = "Serialization Test";
            this.SerializationTab.UseVisualStyleBackColor = true;
            // 
            // DeserializeBtn
            // 
            this.DeserializeBtn.Location = new System.Drawing.Point(163, 216);
            this.DeserializeBtn.Name = "DeserializeBtn";
            this.DeserializeBtn.Size = new System.Drawing.Size(138, 38);
            this.DeserializeBtn.TabIndex = 1;
            this.DeserializeBtn.Text = "Desrialize";
            this.DeserializeBtn.UseVisualStyleBackColor = true;
            this.DeserializeBtn.Click += new System.EventHandler(this.DeserializeBtn_Click);
            // 
            // SerializeBtn
            // 
            this.SerializeBtn.Location = new System.Drawing.Point(163, 152);
            this.SerializeBtn.Name = "SerializeBtn";
            this.SerializeBtn.Size = new System.Drawing.Size(138, 38);
            this.SerializeBtn.TabIndex = 0;
            this.SerializeBtn.Text = "Serialize";
            this.SerializeBtn.UseVisualStyleBackColor = true;
            this.SerializeBtn.Click += new System.EventHandler(this.SerializeBtn_Click);
            // 
            // TestHarness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 524);
            this.Controls.Add(this.TestMenu);
            this.Name = "TestHarness";
            this.Text = "Tesh Harness";
            this.TestMenu.ResumeLayout(false);
            this.EnumerateTab.ResumeLayout(false);
            this.EnumerateTab.PerformLayout();
            this.SerializationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TestMenu;
        private System.Windows.Forms.TabPage EnumerateTab;
        private System.Windows.Forms.ListBox TreeOutputList;
        private System.Windows.Forms.Button IterateBtn;
        private System.Windows.Forms.TabPage SerializationTab;
        private System.Windows.Forms.CheckBox orderChk;
        private System.Windows.Forms.Button DeserializeBtn;
        private System.Windows.Forms.Button SerializeBtn;
    }
}

