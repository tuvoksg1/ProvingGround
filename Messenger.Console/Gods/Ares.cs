using System;
using Messenger.Console.Interfaces;
using Messenger.Console.Models;
using Newtonsoft.Json.Linq;

namespace Messenger.Console.Gods
{
    class Ares : IGod
    {
        private readonly Hermes<PledgeRun> _messenger;
        private readonly Random _randomizer;
        private const string IndexName = "cx_post_ares";
        private const string TypeName = "auditRecord";

        public Ares()
        {
            _randomizer = new Random();
            _messenger = new Hermes<PledgeRun>("ares_template", GetIndexTemplate());
        }

        public void AddMessages()
        {
            var count = _messenger.GetMessageCount(IndexName, TypeName);

            if (count > 0)
            {
                //return;
            }

            var index = 0;

            while (index++ < 50)
            {
                var message = new PledgeRun
                {
                    StartDate = GetDate(true),
                    EndDate = GetDate(false),
                    TenantCode = "MaritzCX",
                    ApplicationSource = "Pledge",
                    Content = $"Pledge {index}",
                    RecordsProcessed = GetCount(),
                    TotalFail = GetCount(),
                    TotalPass = GetCount(),
                    FileName = GetFile(index),
                    RecordId = Guid.NewGuid().ToString(),
                    JobPostId = Guid.NewGuid().ToString(),
                    Message = new Message
                    {
                        Id = Guid.NewGuid().ToString(),
                        EventDate = GetDate(),
                        TenantCode = "MaritzCX",
                        ApplicationSource = "Pledge",
                        Content = $"Event {index}"
                    }
            };

                _messenger.AddMessage(message, IndexName, TypeName);
            }
        }

        public void ListMessages()
        {
            var messages = _messenger.GetMessages(IndexName, TypeName);

            if (messages != null)
            {
                foreach (var item in messages)
                {
                    var message = DataJsonSerializer<PledgeRun>.DeserializeFromJson(item.ToString());

                    if (message == null)
                    {
                        System.Console.WriteLine("Unable to retrieve pledge run data");
                        return;
                    }

                    System.Console.WriteLine($"{message.Content} - File: {message.FileName}, " +
                                             $"Pass: {message.TotalPass}, Fail: {message.TotalFail}");
                }
            }
        }

        private int GetCount()
        {
            return _randomizer.Next(250, 500);
        }

        private static string GetFile(int index)
        {
            var modulus = index % 3;

            switch (modulus)
            {
                case 1:
                    return "First.config";
                case 2:
                    return "Second.config";
                default:
                    return "Third.config";
            }
        }

        private DateTime GetDate(bool isBeforeNow)
        {
            var offset = _randomizer.Next(1, 25);

            if (isBeforeNow)
            {
                offset = offset * -1;
            }

            return DateTime.Now.AddDays(offset);
        }

        private DateTime GetDate()
        {
            var offset = _randomizer.Next(1, 30) * -1;

            //return DateTime.Now.AddDays(offset);
            return DateTime.Now;
        }

        private JObject GetIndexTemplate()
        {
            var request = new JObject
            {
                {"template", IndexName}
            };

            var templates = request.AddObject("mappings").AddObject(TypeName).AddArray("dynamic_templates");

            var jobIdMapping = new JObject {
                { "match", "jobId"},
                { "match_mapping_type", "string"}
            };

            jobIdMapping.AddObject("mapping").Add("type", "keyword");

            var mapJobId = new JObject {{"mapJobId", jobIdMapping}};

            var runIdMapping = new JObject {
                { "match", "runId"},
                { "match_mapping_type", "string"}
            };

            runIdMapping.AddObject("mapping").Add("type", "keyword");

            var mapRunId = new JObject { { "mapRunId", runIdMapping } };

            var messageIdMapping = new JObject
            {
                {"path_match", "message.id"},
                { "match_mapping_type", "string"}
            };

            messageIdMapping.AddObject("mapping").Add("type", "keyword");

            var mapMessageId = new JObject {{"mapMessageId", messageIdMapping}};

            templates.Add(mapJobId);
            templates.Add(mapMessageId);
            templates.Add(mapRunId);

            return request;
        }
    }
}
