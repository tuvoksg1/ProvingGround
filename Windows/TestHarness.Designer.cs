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
            this.IOTab = new System.Windows.Forms.TabPage();
            this.StreamBtn = new System.Windows.Forms.Button();
            this.GetFilesBtn = new System.Windows.Forms.Button();
            this.ElasticTab = new System.Windows.Forms.TabPage();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.IndexBtn = new System.Windows.Forms.Button();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.SearchDateTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TestMenu.SuspendLayout();
            this.EnumerateTab.SuspendLayout();
            this.SerializationTab.SuspendLayout();
            this.IOTab.SuspendLayout();
            this.ElasticTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestMenu
            // 
            this.TestMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestMenu.Controls.Add(this.EnumerateTab);
            this.TestMenu.Controls.Add(this.SerializationTab);
            this.TestMenu.Controls.Add(this.IOTab);
            this.TestMenu.Controls.Add(this.ElasticTab);
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
            // IOTab
            // 
            this.IOTab.Controls.Add(this.StreamBtn);
            this.IOTab.Controls.Add(this.GetFilesBtn);
            this.IOTab.Location = new System.Drawing.Point(4, 22);
            this.IOTab.Name = "IOTab";
            this.IOTab.Padding = new System.Windows.Forms.Padding(3);
            this.IOTab.Size = new System.Drawing.Size(518, 474);
            this.IOTab.TabIndex = 2;
            this.IOTab.Text = "IO Test";
            this.IOTab.UseVisualStyleBackColor = true;
            // 
            // StreamBtn
            // 
            this.StreamBtn.Location = new System.Drawing.Point(33, 116);
            this.StreamBtn.Name = "StreamBtn";
            this.StreamBtn.Size = new System.Drawing.Size(146, 51);
            this.StreamBtn.TabIndex = 1;
            this.StreamBtn.Text = "Run Stream Benchmark Tests";
            this.StreamBtn.UseVisualStyleBackColor = true;
            this.StreamBtn.Click += new System.EventHandler(this.StreamBtn_Click);
            // 
            // GetFilesBtn
            // 
            this.GetFilesBtn.Location = new System.Drawing.Point(33, 25);
            this.GetFilesBtn.Name = "GetFilesBtn";
            this.GetFilesBtn.Size = new System.Drawing.Size(146, 40);
            this.GetFilesBtn.TabIndex = 0;
            this.GetFilesBtn.Text = "Get Files Test";
            this.GetFilesBtn.UseVisualStyleBackColor = true;
            this.GetFilesBtn.Click += new System.EventHandler(this.GetFilesBtn_Click);
            // 
            // ElasticTab
            // 
            this.ElasticTab.Controls.Add(this.label1);
            this.ElasticTab.Controls.Add(this.SearchDateTxt);
            this.ElasticTab.Controls.Add(this.QueryBtn);
            this.ElasticTab.Controls.Add(this.LoadBtn);
            this.ElasticTab.Controls.Add(this.IndexBtn);
            this.ElasticTab.Location = new System.Drawing.Point(4, 22);
            this.ElasticTab.Name = "ElasticTab";
            this.ElasticTab.Padding = new System.Windows.Forms.Padding(3);
            this.ElasticTab.Size = new System.Drawing.Size(518, 474);
            this.ElasticTab.TabIndex = 3;
            this.ElasticTab.Text = "Elastic Search";
            this.ElasticTab.UseVisualStyleBackColor = true;
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(141, 136);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(166, 48);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "Load Audit Data";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // IndexBtn
            // 
            this.IndexBtn.Location = new System.Drawing.Point(141, 66);
            this.IndexBtn.Name = "IndexBtn";
            this.IndexBtn.Size = new System.Drawing.Size(166, 48);
            this.IndexBtn.TabIndex = 0;
            this.IndexBtn.Text = "Create Audit Index";
            this.IndexBtn.UseVisualStyleBackColor = true;
            this.IndexBtn.Click += new System.EventHandler(this.IndexBtn_Click);
            // 
            // QueryBtn
            // 
            this.QueryBtn.Location = new System.Drawing.Point(141, 285);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(166, 52);
            this.QueryBtn.TabIndex = 2;
            this.QueryBtn.Text = "Query Data";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // SearchDateTxt
            // 
            this.SearchDateTxt.Location = new System.Drawing.Point(190, 245);
            this.SearchDateTxt.Name = "SearchDateTxt";
            this.SearchDateTxt.Size = new System.Drawing.Size(117, 20);
            this.SearchDateTxt.TabIndex = 3;
            this.SearchDateTxt.Text = "20150601";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date";
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
            this.IOTab.ResumeLayout(false);
            this.ElasticTab.ResumeLayout(false);
            this.ElasticTab.PerformLayout();
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
        private System.Windows.Forms.TabPage IOTab;
        private System.Windows.Forms.Button GetFilesBtn;
        private System.Windows.Forms.TabPage ElasticTab;
        private System.Windows.Forms.Button IndexBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button StreamBtn;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchDateTxt;
    }
}

