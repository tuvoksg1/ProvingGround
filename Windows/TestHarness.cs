using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Windows.Models.Elastic;
using Windows.Models.Encryption;
using Windows.Models.Extensions;
using Windows.Models.IterateTab;
using Windows.Models.SendGrid;
using Windows.Models.Serialization;
using Elasticsearch.Net;
using Nest;
using Twilio;
using Result = Windows.Models.IterateTab.Result;
using RedisCache;
using Windows.Models.Debugging;
using Utils;

//using Windows.Models.Extensions;

namespace Windows
{
    public partial class TestHarness : Form
    {
        public TestHarness()
        {
            InitializeComponent();
            SessionCombo.SelectedIndex = 0;
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
            //var data = new ComplexObject
            //{
            //    Name = "Sample",
            //    Identifier = Guid.NewGuid(),
            //    Settings = new SerializableDictionary<string, string>
            //    {
            //        {"Name", "Fola"},
            //        {"Company", "MaritzCX"},
            //        {"Project", "Pledge"}
            //    }
            //};

            //var dataXml = data.SerializeToXml();

            //MessageBox.Show(@"Done");
            var data = EnumInfo.ParseEnum<EvaluationOrder>();
            var result = new EnumInfo(ResultType.Exception);

            MessageBox.Show($"{result.Value}");
        }

        private void DeserializeBtn_Click(object sender, EventArgs e)
        {
            var dataXml = @"C:\Users\Fola\XmlData.txt";

            var data = ComplexObject.DeserializeFromFile(dataXml);

            MessageBox.Show(@"Done");
        }


        private static Uri _node;
        private static ConnectionSettings _settings;
        private static ElasticClient _client;

        private void IndexBtn_Click(object sender, EventArgs e)
        {
            //_node = new Uri("http://localhost:9200");
            //_settings = new ConnectionSettings(_node, "auditlog");
            //_client = new ElasticClient(_settings);

            //var indexSettings = new IndexSettings
            //{
            //    NumberOfReplicas = 1,
            //    NumberOfShards = 1
            //};

            //_client.CreateIndex(
            //    arg =>
            //        arg.Index("auditlog")
            //            .InitializeUsing(indexSettings)
            //            .AddMapping<LogEntry>(item => item.MapFromAttributes()));

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
                //_client.Index(log);
            }

            MessageBox.Show($"Loaded {count} logs from DB");
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            var hierarchies = HierarchySearch();

            var versions = hierarchies.Where(arg => arg.Item1 == "Branch" && arg.Item2 == "GB").OrderByDescending(item => item.Item4).ToList();

            if (versions.Any())
            {
                var parsedDate = DateTime.ParseExact(SearchDateTxt.Text, "yyyyMMdd", CultureInfo.InvariantCulture);
                var version = versions.FirstOrDefault(arg => arg.Item4 <= parsedDate);

                if (version != null)
                {
                    MessageBox.Show($"{version.Item3}_{version.Item1}_{version.Item2}");
                }
                else
                {
                    MessageBox.Show(@"No Matching Results");
                }
            }
            else
            {
                MessageBox.Show(@"No Matching Results");
            }
        }

        private static List<Tuple<string, string, string, DateTime>> HierarchySearch()
        {
            var node = new Uri("http://boom-box-1.boomerang.com:9200");
            var config = new ConnectionConfiguration(node);
            var client = new ElasticLowLevelClient(config);
            //var result = client.SearchGet<object>("hsbc_conform", "osf_hierarchies", (arg) => arg.AddQueryString("size", "100"));
            //var root = JObject.FromObject(result.Body);
            var hierarchies = new List<Tuple<string, string, string, DateTime>>();

            //foreach (var item in root["hits"]["hits"])
            //{
            //    var date = item["_source"]["ctl"]["effective_date"].Value<string>();
            //    var country = item["_source"]["conform"]["geography"].Value<string>();
            //    var channel = item["_source"]["conform"]["channel"].Value<string>();

            //    var parsedDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            //    var tuple = Tuple.Create(channel, country, date, parsedDate);
            //    hierarchies.Add(tuple);
            //}

            return hierarchies;
        }

        private async void SendMailBtn_Click(object sender, EventArgs e)
        {
            var cipher = "tc/4qmbuYesQfO4+rflaITfjmeAS47Wc3tV3pX+dD9Q=".Decrypt(string.Empty);
            var crypto = new DataCrypto(cipher);
            var info = new MailServiceInfo
            {
                Host = cipher,
                DisplayName = "Joe Bloggs",
                MailAccount = "CqhpePRgzEzIaLH87Th/wSACwmIe6gR57DbKKOLM+nJ9FNhuT7d2yuK3+XJFEkyaknH375vyS55S3eRdp1mfxZ2YQGcKl2t6sG3SjLeaXas=".Decrypt(cipher),
                Password = "9XW1J+TODt0dk6Sz/4a4HmnwhP6O8PaVpaLIkbIkZ5w=".Decrypt(cipher),
                PortNumber = 10000,
                SendAddress = "nobody@nowhere.com",
                Timeout = 25000
            };

            var message = new EmailMessage
            {
                Body = "This email shows that the debug code is working",
                Destination = "fola.sonoiki@maritzcx.com",
                Subject = "Test Email"
            };

            var service = new EmailService(info);
            await service.SendAsync(message);
        }

        private void SendSMSButton_Click(object sender, EventArgs e)
        {
            //var originalText = "https://localhost:44340/core/connect/authorize?client_id=listservice&redirect_uri=http%3A%2F%2Flocalhost%3A52300%2FList%2FIndex%2F&response_mode=form_post&response_type=code%20id_token%20token&scope=openid%20profile%20offline_access%20api%20listservice&state=OpenIdConnect.AuthenticationProperties%3DpbyYssoNwD_DtPGpLAXpUcqGFbnzEVCUHStyLL_flr2Q5qhC-wuTp3zMK85SCLXnDKyyFN_Q3-Li-yLE35icB67DICo3sVp_pYXhkKiBlIWwtGvD0Xwkszuja0f9DEaPqH3LGUOPn6GJUI35k_gg18EOxNtUabMHYvSBTZK3rPG3Y3_9FtrjW9ysHN5N1j0rawPyqrYB4fWW9IETq2QcQg&nonce=636067951330093052.NzkwNjRjYjQtOGYxOC00MTFlLTk3ZTMtMDBlMmI3ZDQ1MTYxMWI4MDI0ZjktNTM5ZS00NTYwLThlYzctZWNiNzgxYjM1YzZm";

            //var queryStringCollection = HttpUtility.ParseQueryString(originalText, Encoding.UTF8);

            //var redirectUrl = queryStringCollection["redirect_uri"];
            //var finalText = HttpUtility.UrlDecode(redirectUrl, Encoding.UTF8);
            var cipher = "FSjD4t6pvSgMI4sVXaY7YqBhvQ/qejpTqPfcQY4FHgE=".Decrypt(string.Empty);
            var accountId = "mBK9T/a4LR1OwmgWzJb9djOzfMVb05iOwvxa1f31eCHre4mX3kNxUeL164kiWLPg".Decrypt(cipher);
            var authToken = "lV9xMSRaofUDBDMH3kiFLFJsLztFW5WcbeuMzs2sM7jqlH5oWie2yC4k6RXMIoAB".Decrypt(cipher);
            var twilio = new TwilioRestClient(accountId, authToken);

            var result = twilio.SendMessage("+447481344084", "+447944062159", "2FA Test");

            Trace.TraceInformation(result.Status);

            MessageBox.Show(@"Message Sent");
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            //EvalauteConditional();
            EvaulateEnums(DataBox.Text);
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            var plainText = plainTxt.Text;
            var passphrase = encPhraseTxt.Text;

            encTxt.Text = plainText.Encrypt(passphrase);
            decrPhraseTxt.Text = passphrase;
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            var encryptedText = encTxt.Text;
            var passphrase = decrPhraseTxt.Text;

            resultTxt.Text = encryptedText.Decrypt(passphrase);
        }

        private readonly JobServer _jobServer = new JobServer();
        private void FetchBtn_Click(object sender, EventArgs e)
        {
            FetchItems();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResultListBox.Items.Clear();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (pagePicker.Value > pagePicker.Minimum)
            {
                --pagePicker.Value;
            }
            FetchItems();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if(pagePicker.Value < pagePicker.Maximum)
            {
                ++pagePicker.Value;
            }

            FetchItems();
        }

        private void FetchItems()
        {
            var page = (int)pagePicker.Value;
            var sessionId = SessionCombo.SelectedItem.ToString();
            var results = _jobServer.GetJobs(sessionId, page);

            ResultListBox.Items.Add($"Page {page} search for {sessionId}");
            ResultListBox.Items.AddRange(results.Select((item, index) => $"{++index} {item}").ToArray());
            ResultListBox.Items.Add("******************************************");
        }

        private void EvalauteConditional()
        {
            var car = new Car
            {
                Seats = new List<Seat>(),
                Wheels = new List<Wheel>
                {
                    new Wheel{ Position = "Front Left"},
                    new Wheel{ Position = "Front Right"},
                    new Wheel{ Position = "Rear Left"},
                    new Wheel{ Position = "Rear Right"}
                }
            };

            var factory = new Factory();

            string text = "Undefined";
            Car wheel = null;
            switch (wheel?.Wheelbase)
            {
                case Wheelbase.Short:
                    text = "Short";
                    break;
                case Wheelbase.Long:
                    text = "Long";
                    break;
                default:
                    text = "None";
                    break;
            }
            MessageBox.Show(text);

            //MessageBox.Show(factory.Inspect(car, "MOT Pass"));
        }

        private void EvaulateEnums(string manufacturerName)
        {
            if(!Enum.IsDefined(typeof(Manufacturer), manufacturerName))
            {
                return;
            }


            //var configList = new List<Manufacturer> { Manufacturer.Ford, Manufacturer.Renault,
            //    Manufacturer.Tesla, Manufacturer.Toyota, Manufacturer.Renault };

            //JsonHelper.ToFile(configList, "Manufacturers.json");

            if (Enum.TryParse<Manufacturer>(manufacturerName, out var manufacturer))
            {
                var message = manufacturer >= Manufacturer.Renault ? $"{manufacturer} is a sanctioned manufacturer" :
                $"{manufacturer} is NOT a sanctioned manufacturer";

                MessageBox.Show(message);
            }

        }

        private void EvaulateEnums(Manufacturer manufacturer)
        {
            var data = JsonHelper.FromFile<List<Manufacturer>>("Manufacturers.json");
            var combine = new HashSet<Manufacturer>(data);

            var message = combine.Contains(manufacturer) ? $"{manufacturer} is a sanctioned manufacturer" :
                $"{manufacturer} is NOT a sanctioned manufacturer";

            MessageBox.Show(message);
        }
    }
}
