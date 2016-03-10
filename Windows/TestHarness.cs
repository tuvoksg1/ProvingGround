using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Windows.Models.Elastic;
using Windows.Models.IterateTab;
using Windows.Models.Serialization;
using Windows.Models.Stream;
using Elasticsearch.Net.Connection;
using Nest;

namespace Windows
{
    public partial class TestHarness : Form
    {
        public TestHarness()
        {
            InitializeComponent();
        }

        private void OnIterateClick(object sender, EventArgs e)
        {
            var date = DateTime.Parse("Tue, 31 Mar 2015 23:00:00 GMT");

            MessageBox.Show(date.ToString());
            //TreeOutputList.Items.Clear();
            //var evaluateOrder = orderChk.Checked ? EvaluationOrder.ParentFirst : EvaluationOrder.ChildrenFirst;

            //var data = NodeData.GetNodes();

            //foreach (var node in data)
            //{
            //    var currentLevel = 0;
            //    IResult currentResult = new Result { Type = ResultType.NotRun };

            //    foreach (var member in node.GetEnumerable(evaluateOrder))
            //    {
            //        //if we are going downwards, reset the rolling result and level number
            //        if (member.Level > currentLevel)
            //        {
            //            currentResult = new Result { Type = ResultType.Pass };
            //            currentLevel = member.Level;
            //        }

            //        currentResult = member.Evaluate(currentResult);
            //        //currentResult.Type = ResultType.Exception;

            //        TreeOutputList.Items.Add($"{member} Rolling Result: {currentResult.Type}");
            //    }
            //}

            //EvaluateNodes();
        }

        private void EvaluateNodes()
        {
            TreeOutputList.Items.Clear();

            var data = NodeData.GetNodes();

            foreach (var node in data)
            {
                IResult result = new Result { Type = ResultType.Pass };

                result = node.Evaluate(result);

                //TreeOutputList.Items.Add($"{node} Rolling Result: {result.Type}");

                if (result.Type == ResultType.Pass && node.Children.Any())
                {
                    result = EvaluateNode(node);
                }

                TreeOutputList.Items.Add($"{node} Rolling Result: {result.Type}");
            }
        }

        private IResult EvaluateNode(ITreeNode parent)
        {
            IResult result = new Result {Type = ResultType.Pass};

            foreach (var node in parent.Children)
            {
                result = node.Evaluate(result);

                TreeOutputList.Items.Add($"{node} Rolling Result: {result.Type}");

                if (node.Outcome.Type == ResultType.Pass)
                {
                    if (node.Children.Any())
                    {
                        result = EvaluateNode(node);

                        //if my children evaulated to Pass and I'm an OR, bubble up to the nearest AND ancestor
                        if (result.Type == ResultType.Pass && node.LogicType == LogicType.Or)
                        {
                            break;
                        }
                    }
                    else
                    {
                        //if I have no children and I'm an OR bubble up to the nearest ancestor
                        if (node.LogicType == LogicType.Or)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private void SerializeBtn_Click(object sender, EventArgs e)
        {
            var data = new ComplexObject
            {
                Name = "Sample",
                Identifier = Guid.NewGuid(),
                Settings = new SerializableDictionary<string, string>
                {
                    {"Name", "Fola"},
                    {"Company", "MaritzCX"},
                    {"Project", "Pledge"}
                }
            };

            var dataXml = data.SerializeToXml();

            MessageBox.Show(@"Done");
        }

        private void DeserializeBtn_Click(object sender, EventArgs e)
        {
            var dataXml = @"C:\Users\Fola\XmlData.txt";

            var data = ComplexObject.DeserializeFromFile(dataXml);

            MessageBox.Show(@"Done");
        }

        private void GetFilesBtn_Click(object sender, EventArgs e)
        {
            const string directory = @"C:\Users\sonoikf\Code\Common\PledgeMCX\Development\Pledge\netwrite\Export";
            const string pattern = "PledgeConfiguration_2*";

            var count = Directory.GetFiles(directory, pattern);

            MessageBox.Show($"Detected {count.Length} files in the directory");
        }

        private static Uri _node;
        private static ConnectionSettings _settings;
        private static ElasticClient _client;

        private void IndexBtn_Click(object sender, EventArgs e)
        {
            _node = new Uri("http://localhost:9200");
            _settings = new ConnectionSettings(_node, "auditlog");
            _client = new ElasticClient(_settings);

            var indexSettings = new IndexSettings
            {
                NumberOfReplicas = 1,
                NumberOfShards = 1
            };

            _client.CreateIndex(
                arg =>
                    arg.Index("auditlog")
                        .InitializeUsing(indexSettings)
                        .AddMapping<LogEntry>(item => item.MapFromAttributes()));

            MessageBox.Show(@"Index successfully created");
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            var repo = new Repository();
            var logs = repo.GetAuditLogs();
            var count = 0;

            foreach (var log in logs)
            {
                count++;
                _client.Index(log);
            }

            MessageBox.Show($"Loaded {count} logs from DB");
        }

        private void StreamBtn_Click(object sender, EventArgs e)
        {
            StreamProcessor.Start();

            MessageBox.Show(@"Processing complete");
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            var node = new Uri("http://myserver:9200");
            var config = new ConnectionConfiguration(node);
            //var client = new ElasticLowLevelClient(config);
        }
    }
}
