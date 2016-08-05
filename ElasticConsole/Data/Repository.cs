using System;
using System.Collections.Generic;
using System.Linq;
using ElasticConsole.Models;
using Nest;

namespace ElasticConsole.Data
{
    internal class Repository
    {
        private static readonly string _indexName = "cx_passport";
        private ElasticClient _client;

        public Repository()
        {
            InitialiseConnection();
        }

        private void InitialiseConnection()
        {
            var local = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(local).DefaultIndex(_indexName);
            _client = new ElasticClient(settings);

            var res = _client.LowLevel.ClusterHealth<object>();

            Console.WriteLine(res.SuccessOrKnownError);

            res = _client.LowLevel.IndicesExists<object>(_indexName);

            if (res.HttpStatusCode != 200)
            {
                Console.WriteLine($"{_indexName} Index does not exist - Initialising");
                InitialiseIndex();

                Console.WriteLine("Populating index....");
                AddClientsToStorage();
            }
            else
            {
                Console.WriteLine($"{_indexName} Index is accesible");
            }
        }

        private void InitialiseIndex()
        {
            _client.CreateIndex(new IndexName
            {
                Type = typeof (BlogPost)
            }, ci => ci
                .Mappings(ms => ms
                    .Map<ClientModel>(m => m.AutoMap()
                        .Properties(prop => prop
                            .String(field => field
                                .Name(name => name.Handle)
                                .Index(FieldIndexOption.Analyzed))
                            .String(field => field
                                .Name(name => name.Name)
                                .Index(FieldIndexOption.Analyzed))
                            .Boolean(field => field
                                .Name(name => name.IsDisabled)
                                .Index(NonStringIndexOption.No))
                            .Boolean(field => field
                                .Name(name => name.RequiresAllGrants)
                                .Index(NonStringIndexOption.No))
                            .Boolean(field => field
                                .Name(name => name.RequiresRefreshToken)
                                .Index(NonStringIndexOption.No))
                            .Number(field => field
                                .Name(name => name.Type)
                                .Index(NonStringIndexOption.No))
                            .String(field => field
                                .Name(name => name.Handle)
                                .Index(FieldIndexOption.Analyzed))
                            .String(field => field
                                .Name(name => name.Name)
                                .Index(FieldIndexOption.Analyzed))))
                ));

            Console.WriteLine($"{_indexName} Index created");
        }

        private void AddClientsToStorage()
        {
            var clients = Storage.Clients();

            foreach (var client in clients)
            {
                _client.Index(client, p => p
                    .Id(client.Id.ToString())
                    .Refresh());
            }

            Console.WriteLine($"{clients.Count} Clients indexed");
        }

        public void QueryClients()
        {
            var result = _client.Search<ClientModel>(s => s
                .From(0)
                .Size(20)
                .Query(q => q.MatchAll())
                .Sort(o => o.Ascending(p => p.Handle)));

            var total = result.Hits.Count();

            if (total > 0)
            {
                Console.WriteLine($"Found {result.Hits.Count()} results...");

                foreach (var hit in result.Hits)
                {
                    Console.WriteLine(hit.Source);
                }
            }
            else
            {
                Console.WriteLine("No Results found");
            }
        }

        public List<ClientModel> FindClient(string handle)
        {
            var clients = new List<ClientModel>();

            var result = _client.Search<ClientModel>(search => search
                .Query(query => query
                    .Bool(boolQuery => boolQuery
                        .Must(must =>
                            must.Match(match => match.Field(field => field.Handle).Query(handle)))))
                .Sort(o => o.Ascending(p => p.Handle)));

            var total = result.Hits.Count();

            if (total > 0)
            {
                Console.WriteLine($"Found {result.Hits.Count()} results...");

                foreach (var hit in result.Hits)
                {
                    clients.Add(hit.Source);
                    Console.WriteLine(hit.Source);
                }
            }
            else
            {
                Console.WriteLine("No Results found");
            }

            return clients;
        }

        public void DeleteClient(string handle)
        {
            var deletedObjects = _client.Search<ClientModel>(index => index
                .Type<ClientModel>()
                .Query(filter => filter.Term(e => e.Handle, handle))
                );

            var deleteResults = deletedObjects.Hits.Select(hit =>
                _client.Delete(new DocumentPath<ClientModel>(hit.Id)
                .Type(hit.Type), item => item.Refresh())
            );

            var deleteCount = deleteResults.Count(arg => arg.ApiCall.Success);
            Console.WriteLine($"Deleted {deleteCount} matching clients");
        }

        public void UpdateClient(ClientModel model)
        {
            var result = _client.Update<ClientModel>(model.Id.ToString(), (item) => item.Doc(model).Refresh());

            Console.WriteLine(result.ApiCall.Success
                ? $"Updated client with handle: {model.Handle}"
                : $"Unable to update client with handle: {model.Handle}");
        }
    }
}
