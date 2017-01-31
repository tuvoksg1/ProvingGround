using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RootBtn_Click(object sender, EventArgs e)
        {
            var result = RootBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                FolderTxt.Text = RootBrowser.SelectedPath;
            }
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            var files = !string.IsNullOrWhiteSpace(PatternTxt.Text) ? 
                Directory.GetFiles(FolderTxt.Text, PatternTxt.Text, SearchOption.AllDirectories) : 
                Directory.GetFiles(FolderTxt.Text, "*.*", SearchOption.AllDirectories);

            var builder = new StringBuilder("File, SourceFolder, Valid, Processed");
            builder.AppendLine();

            foreach (var file in files)
            {
                builder.AppendLine($"{Path.GetFileName(file)}, {Path.GetDirectoryName(file)}, ,");
            }

            var outputFile = Path.Combine(FolderTxt.Text, "ScanResult.csv");

            using (var fileWriter = new StreamWriter(outputFile, false))
            {
                fileWriter.Write(builder.ToString());
            }

            MessageBox.Show(@"Scan Complete");
        }
    }
}
