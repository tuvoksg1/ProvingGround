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
            this.SessionCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FetchBtn = new System.Windows.Forms.Button();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.pagePicker = new System.Windows.Forms.NumericUpDown();
            this.ElasticTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchDateTxt = new System.Windows.Forms.TextBox();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.IndexBtn = new System.Windows.Forms.Button();
            this.MailTab = new System.Windows.Forms.TabPage();
            this.SendSMSButton = new System.Windows.Forms.Button();
            this.SendMailBtn = new System.Windows.Forms.Button();
            this.TestTab = new System.Windows.Forms.TabPage();
            this.TestBtn = new System.Windows.Forms.Button();
            this.cryptoTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.resultTxt = new System.Windows.Forms.TextBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.decrPhraseTxt = new System.Windows.Forms.TextBox();
            this.encTxt = new System.Windows.Forms.TextBox();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.encPhraseTxt = new System.Windows.Forms.TextBox();
            this.plainTxt = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.TestMenu.SuspendLayout();
            this.EnumerateTab.SuspendLayout();
            this.SerializationTab.SuspendLayout();
            this.IOTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagePicker)).BeginInit();
            this.ElasticTab.SuspendLayout();
            this.MailTab.SuspendLayout();
            this.TestTab.SuspendLayout();
            this.cryptoTab.SuspendLayout();
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
            this.TestMenu.Controls.Add(this.MailTab);
            this.TestMenu.Controls.Add(this.TestTab);
            this.TestMenu.Controls.Add(this.cryptoTab);
            this.TestMenu.Location = new System.Drawing.Point(12, 12);
            this.TestMenu.Name = "TestMenu";
            this.TestMenu.SelectedIndex = 0;
            this.TestMenu.Size = new System.Drawing.Size(619, 517);
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
            this.EnumerateTab.Size = new System.Drawing.Size(611, 491);
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
            this.TreeOutputList.Size = new System.Drawing.Size(564, 394);
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
            this.SerializationTab.Size = new System.Drawing.Size(611, 491);
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
            this.IOTab.Controls.Add(this.ClearBtn);
            this.IOTab.Controls.Add(this.SessionCombo);
            this.IOTab.Controls.Add(this.label7);
            this.IOTab.Controls.Add(this.FetchBtn);
            this.IOTab.Controls.Add(this.ResultListBox);
            this.IOTab.Controls.Add(this.pagePicker);
            this.IOTab.Location = new System.Drawing.Point(4, 22);
            this.IOTab.Name = "IOTab";
            this.IOTab.Padding = new System.Windows.Forms.Padding(3);
            this.IOTab.Size = new System.Drawing.Size(611, 491);
            this.IOTab.TabIndex = 2;
            this.IOTab.Text = "Redis Cache";
            this.IOTab.UseVisualStyleBackColor = true;
            // 
            // SessionCombo
            // 
            this.SessionCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SessionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SessionCombo.FormattingEnabled = true;
            this.SessionCombo.Items.AddRange(new object[] {
            "Chris",
            "Fola",
            "James",
            "Shlomi",
            "Andy",
            "Dave"});
            this.SessionCombo.Location = new System.Drawing.Point(15, 15);
            this.SessionCombo.Name = "SessionCombo";
            this.SessionCombo.Size = new System.Drawing.Size(121, 21);
            this.SessionCombo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Page";
            // 
            // FetchBtn
            // 
            this.FetchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FetchBtn.Location = new System.Drawing.Point(15, 112);
            this.FetchBtn.Name = "FetchBtn";
            this.FetchBtn.Size = new System.Drawing.Size(121, 23);
            this.FetchBtn.TabIndex = 2;
            this.FetchBtn.Text = "Fetch";
            this.FetchBtn.UseVisualStyleBackColor = true;
            this.FetchBtn.Click += new System.EventHandler(this.FetchBtn_Click);
            // 
            // ResultListBox
            // 
            this.ResultListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.Location = new System.Drawing.Point(162, 15);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(415, 459);
            this.ResultListBox.TabIndex = 1;
            // 
            // pagePicker
            // 
            this.pagePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pagePicker.Location = new System.Drawing.Point(50, 66);
            this.pagePicker.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pagePicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pagePicker.Name = "pagePicker";
            this.pagePicker.Size = new System.Drawing.Size(86, 20);
            this.pagePicker.TabIndex = 0;
            this.pagePicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.ElasticTab.Size = new System.Drawing.Size(611, 491);
            this.ElasticTab.TabIndex = 3;
            this.ElasticTab.Text = "Elastic Search";
            this.ElasticTab.UseVisualStyleBackColor = true;
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
            // SearchDateTxt
            // 
            this.SearchDateTxt.Location = new System.Drawing.Point(190, 245);
            this.SearchDateTxt.Name = "SearchDateTxt";
            this.SearchDateTxt.Size = new System.Drawing.Size(117, 20);
            this.SearchDateTxt.TabIndex = 3;
            this.SearchDateTxt.Text = "20150601";
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
            // MailTab
            // 
            this.MailTab.Controls.Add(this.SendSMSButton);
            this.MailTab.Controls.Add(this.SendMailBtn);
            this.MailTab.Location = new System.Drawing.Point(4, 22);
            this.MailTab.Name = "MailTab";
            this.MailTab.Padding = new System.Windows.Forms.Padding(3);
            this.MailTab.Size = new System.Drawing.Size(611, 491);
            this.MailTab.TabIndex = 4;
            this.MailTab.Text = " SendGrid Mail";
            this.MailTab.UseVisualStyleBackColor = true;
            // 
            // SendSMSButton
            // 
            this.SendSMSButton.Location = new System.Drawing.Point(175, 173);
            this.SendSMSButton.Name = "SendSMSButton";
            this.SendSMSButton.Size = new System.Drawing.Size(146, 34);
            this.SendSMSButton.TabIndex = 1;
            this.SendSMSButton.Text = "Send SMS";
            this.SendSMSButton.UseVisualStyleBackColor = true;
            this.SendSMSButton.Click += new System.EventHandler(this.SendSMSButton_Click);
            // 
            // SendMailBtn
            // 
            this.SendMailBtn.Location = new System.Drawing.Point(175, 105);
            this.SendMailBtn.Name = "SendMailBtn";
            this.SendMailBtn.Size = new System.Drawing.Size(146, 33);
            this.SendMailBtn.TabIndex = 0;
            this.SendMailBtn.Text = "Send Mail";
            this.SendMailBtn.UseVisualStyleBackColor = true;
            this.SendMailBtn.Click += new System.EventHandler(this.SendMailBtn_Click);
            // 
            // TestTab
            // 
            this.TestTab.Controls.Add(this.TestBtn);
            this.TestTab.Location = new System.Drawing.Point(4, 22);
            this.TestTab.Name = "TestTab";
            this.TestTab.Padding = new System.Windows.Forms.Padding(3);
            this.TestTab.Size = new System.Drawing.Size(611, 491);
            this.TestTab.TabIndex = 5;
            this.TestTab.Text = "Run Test";
            this.TestTab.UseVisualStyleBackColor = true;
            // 
            // TestBtn
            // 
            this.TestBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestBtn.Location = new System.Drawing.Point(200, 179);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(194, 56);
            this.TestBtn.TabIndex = 0;
            this.TestBtn.Text = "Execute";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // cryptoTab
            // 
            this.cryptoTab.Controls.Add(this.label6);
            this.cryptoTab.Controls.Add(this.resultTxt);
            this.cryptoTab.Controls.Add(this.decryptBtn);
            this.cryptoTab.Controls.Add(this.label4);
            this.cryptoTab.Controls.Add(this.label5);
            this.cryptoTab.Controls.Add(this.decrPhraseTxt);
            this.cryptoTab.Controls.Add(this.encTxt);
            this.cryptoTab.Controls.Add(this.encryptBtn);
            this.cryptoTab.Controls.Add(this.label3);
            this.cryptoTab.Controls.Add(this.label2);
            this.cryptoTab.Controls.Add(this.encPhraseTxt);
            this.cryptoTab.Controls.Add(this.plainTxt);
            this.cryptoTab.Location = new System.Drawing.Point(4, 22);
            this.cryptoTab.Name = "cryptoTab";
            this.cryptoTab.Size = new System.Drawing.Size(611, 491);
            this.cryptoTab.TabIndex = 6;
            this.cryptoTab.Text = "Encryption";
            this.cryptoTab.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Result";
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(73, 225);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(343, 20);
            this.resultTxt.TabIndex = 10;
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(431, 151);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(75, 23);
            this.decryptBtn.TabIndex = 9;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Passphrase";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Crypto Text";
            // 
            // decrPhraseTxt
            // 
            this.decrPhraseTxt.Location = new System.Drawing.Point(272, 154);
            this.decrPhraseTxt.Name = "decrPhraseTxt";
            this.decrPhraseTxt.Size = new System.Drawing.Size(144, 20);
            this.decrPhraseTxt.TabIndex = 6;
            // 
            // encTxt
            // 
            this.encTxt.Location = new System.Drawing.Point(73, 154);
            this.encTxt.Name = "encTxt";
            this.encTxt.Size = new System.Drawing.Size(125, 20);
            this.encTxt.TabIndex = 5;
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(431, 80);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(75, 23);
            this.encryptBtn.TabIndex = 4;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Passphrase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plain Text";
            // 
            // encPhraseTxt
            // 
            this.encPhraseTxt.Location = new System.Drawing.Point(272, 83);
            this.encPhraseTxt.Name = "encPhraseTxt";
            this.encPhraseTxt.Size = new System.Drawing.Size(144, 20);
            this.encPhraseTxt.TabIndex = 1;
            this.encPhraseTxt.Text = "World";
            // 
            // plainTxt
            // 
            this.plainTxt.Location = new System.Drawing.Point(73, 83);
            this.plainTxt.Name = "plainTxt";
            this.plainTxt.Size = new System.Drawing.Size(125, 20);
            this.plainTxt.TabIndex = 0;
            this.plainTxt.Text = "Hello";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(15, 376);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(121, 23);
            this.ClearBtn.TabIndex = 5;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // TestHarness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 541);
            this.Controls.Add(this.TestMenu);
            this.Name = "TestHarness";
            this.Text = "Tesh Harness";
            this.TestMenu.ResumeLayout(false);
            this.EnumerateTab.ResumeLayout(false);
            this.EnumerateTab.PerformLayout();
            this.SerializationTab.ResumeLayout(false);
            this.IOTab.ResumeLayout(false);
            this.IOTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagePicker)).EndInit();
            this.ElasticTab.ResumeLayout(false);
            this.ElasticTab.PerformLayout();
            this.MailTab.ResumeLayout(false);
            this.TestTab.ResumeLayout(false);
            this.cryptoTab.ResumeLayout(false);
            this.cryptoTab.PerformLayout();
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
        private System.Windows.Forms.TabPage ElasticTab;
        private System.Windows.Forms.Button IndexBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchDateTxt;
        private System.Windows.Forms.TabPage MailTab;
        private System.Windows.Forms.Button SendMailBtn;
        private System.Windows.Forms.Button SendSMSButton;
        private System.Windows.Forms.TabPage TestTab;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.TabPage cryptoTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox resultTxt;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox decrPhraseTxt;
        private System.Windows.Forms.TextBox encTxt;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox encPhraseTxt;
        private System.Windows.Forms.TextBox plainTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button FetchBtn;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.NumericUpDown pagePicker;
        private System.Windows.Forms.ComboBox SessionCombo;
        private System.Windows.Forms.Button ClearBtn;
    }
}

