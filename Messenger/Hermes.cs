using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messenger
{
    public class Hermes<T> where T : class
    {
        private const string DefaultIndex = "mount_olympus";
        private const string ServerUrl = "localhost:9200";
        private readonly ElasticClient _client;
        private readonly string _index;

        public Hermes(string indexTemplate, JObject templateDefinition)
        {
            const string userName = "elastic";
            const string password = "changeme";
            var local = new Uri($"http://{userName}:{password}@{ServerUrl}");
            var settings = new ConnectionSettings(local)
                .DefaultIndex(DefaultIndex)
                .DisableDirectStreaming();
            _client = new ElasticClient(settings);

            var res = _client.LowLevel.ClusterHealth<object>();

            if (!res.SuccessOrKnownError)
            {
                throw new InvalidOperationException("Elastic search server is not reachable");
            }

            //InitialiseIndex(indexTemplate, templateDefinition);
        }

        public Hermes(string index)
        {
            const string userName = "elastic";
            const string password = "changeme";
            var local = new Uri($"http://{userName}:{password}@{ServerUrl}");
            var settings = new ConnectionSettings(local).DefaultIndex(DefaultIndex);
            _client = new ElasticClient(settings);

            var res = _client.LowLevel.ClusterHealth<object>();

            if (res.SuccessOrKnownError)
            {
                res = _client.LowLevel.IndicesExists<object>(index);

                if (res.HttpStatusCode != 200)
                {
                    Console.WriteLine($"{index} Index does not exist - Initialising");
                    InitialiseIndex(index);
                }
                else
                {
                    Console.WriteLine($"{index} Index is accesible");
                }

                _index = index;
            }
            else
            {
                throw new InvalidOperationException("Elastic search server is not reachable");
            }
        }

        private void InitialiseIndex(string index)
        {
            var response = _client.CreateIndex(new IndexName
            {
                Name = index,
                Type = typeof(T)
            }, ci => ci
                .Mappings(ms => ms
                    .Map<T>(m => m.AutoMap())));

            if (!response.IsValid)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
            }
        }

        private void InitialiseIndex(string indexTemplate, JObject templateDefinition)
        {
            var response = _client.LowLevel.IndicesPutTemplateForAll<object>(indexTemplate, new PostData<object>(templateDefinition.ToString()));

            if (!response.Success)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
                return;
            }

            Console.WriteLine($"{indexTemplate} template registered");
        }

        public void AddMessage(T message)
        {
            var response = _client.Index(message, p => p
                        .Index(_index)
                        //.Id(message.Id)
                        .Refresh(new Refresh()));

            if (!response.IsValid)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
            }
        }

        public void AddMessage(object message, string index, string type)
        {
            var response = _client.LowLevel.Index<object>(index, type, new PostData<object>(message));

            if (!response.Success)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
            }
        }

        public IEnumerable<T> GetMessages()
        {
            var response = _client.Search<T>(s => s
                .Index(_index)
                .From(0)
                .Size(100)
                .Query(q => q.MatchAll()));

            if (!response.IsValid)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
                return null;
            }

            return response.ApiCall.Success ? response.Hits.Select(arg => arg.Source) : new List<T>();
        }

        public IEnumerable<object> GetMessages(string index, string type)
        {
            var response = _client.LowLevel.SearchGet<object>(index, type, arg => arg.AddQueryString("size", "10000"));

            if (!response.Success)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
                return null;
            }

            var bytesAsString = Encoding.UTF8.GetString(response.ResponseBodyInBytes);
            var root = JObject.FromObject(JsonConvert.DeserializeObject(bytesAsString));

            return root["hits"]["hits"]
                .Select(item => item["_source"].ToString())
                .Select(JsonConvert.DeserializeObject).ToList();
        }

        public long GetMessageCount()
        {
            var response = _client.Count<T>(search => search
                    .Index(_index));

            if (!response.IsValid)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
                return -1;
            }

            return response.Count;
        }

        public long GetMessageCount(string index, string type)
        {
            var response = _client.LowLevel.Count<object>(index, type, null, null);

            if (!response.Success)
            {
                Console.WriteLine($"{response.ServerError.Error.Reason}");
                return -1;
            }

            var bytesAsString = Encoding.UTF8.GetString(response.ResponseBodyInBytes);
            var root = JObject.FromObject(JsonConvert.DeserializeObject(bytesAsString));

            return (int )root["count"];
        }
    }
}
