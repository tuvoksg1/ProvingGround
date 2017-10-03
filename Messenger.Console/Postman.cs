using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using KafkaNet;
using KafkaNet.Model;
using Newtonsoft.Json.Linq;

namespace Messenger.Console
{
    class Postman
    {
        public static async void Spam()
        {
            var kafkaOptions = new KafkaOptions
            {
                KafkaServerUri = new List<Uri> { new Uri("http://localhost:9092") },
                MaximumReconnectionTimeout = TimeSpan.FromSeconds(10),
                ResponseTimeoutMs = TimeSpan.FromSeconds(10)
            };

            try
            {
                var kafkaProducer = new Producer(new BrokerRouter(kafkaOptions))
                {
                    BatchSize = 100,
                    BatchDelayTime = TimeSpan.FromMilliseconds(2000)
                };

                var index = 1;

                while (index <= 5)
                {
                    var id = Guid.NewGuid().ToString();
                    var record = new JObject
                    {
                        {"MessageId", id},
                        {"ClientName", "Postman"},
                        {"TargetIndex", "cx_post_man"},
                        {"TargetType", "auditRecord"},
                        {
                            "Payload", new JObject
                            {
                                {"FirstName", "Fola"},
                                {"LastName", "Sonoiki"},
                                {"Code", $"Postman_{index}"},
                                {"RecordId", id}
                            }
                        }
                    };

                    Debug.WriteLine($"Spamming {id} for Postman");

#pragma warning disable 4014
                    await kafkaProducer.SendMessageAsync("cx_post_audit",
                        new[] { new KafkaNet.Protocol.Message(record.ToString()) });
#pragma warning restore 4014
                    index++;
                }
            }
            catch (Exception error)
            {
                Debug.Write($"Error connecting to Kafka: {error.Message}");
            }
        }
    }
}
