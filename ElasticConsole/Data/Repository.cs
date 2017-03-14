using System;
using System.Collections.Generic;
using System.Linq;
using ElasticConsole.Models;
using Nest;

namespace ElasticConsole.Data
{
    internal class Repository
    {
        private readonly IElasticClient _client;

        public Repository()
        {
            var storage = new Storage("http://localhost:9200");
            _client = storage.Connection;
        }

        public void QueryClients()
        {
            var result = _client.Search<ServiceModel>(s => s
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

        public List<ServiceModel> FindClient(string handle)
        {
            var clients = new List<ServiceModel>();

            var result = _client.Search<ServiceModel>(search => search
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
            var deletedObjects = _client.Search<ServiceModel>(index => index
                .Type<ServiceModel>()
                .Query(filter => filter.Term(e => e.Handle, handle))
                );

            var deleteResults = deletedObjects.Hits.Select(hit =>
                _client.Delete(new DocumentPath<ServiceModel>(hit.Id)
                .Type(hit.Type), item => item.Refresh())
            );

            var deleteCount = deleteResults.Count(arg => arg.ApiCall.Success);
            Console.WriteLine($"Deleted {deleteCount} matching clients");
        }

        public void UpdateClient(ServiceModel model)
        {
            var result = _client.Update<ServiceModel>(model.Id.ToString(), item => item.Doc(model).Refresh());

            Console.WriteLine(result.ApiCall.Success
                ? $"Updated client with handle: {model.Handle}"
                : $"Unable to update client with handle: {model.Handle}");
        }

        public IEnumerable<Models.User> GetUsersForOrganisation(string orgId)
        {
            var matchResult = _client.Search<Models.User>(search =>
                search.Index(Storage.UserIndex)
                    .Query(query => query.Term(term =>
                        term.Field(field => field.TenantId)
                            .Value(orgId.ToString())))
                            .Sort(sort => sort.Ascending(field => field.UserName)));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<Models.User>();
        }

        public IEnumerable<ClaimModel> GetClaimsForOrganisation(string orgId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(Storage.ClaimIndex)
                    .Query(query => query.Term(term => term
                        .Field(field => field.Owner)
                        .Value(orgId.ToString()))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public IEnumerable<ClaimModel> GetClaimsForService(string serviceId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(Storage.ClaimIndex)
                    .Query(query => query.Term(term => term
                        .Field(field => field.Owner)
                        .Value(serviceId.ToString()))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public Models.User FindUser(string userName)
        {
            var result = _client.Search<Models.User>(search => search
                .Index(Storage.UserIndex)
                .Query(query => query
                    .Term(term => term
                        .Field(field => field.UserName)
                        .Value(userName))));

            var total = result.Hits.Count();

            if (total <= 0) return null;

            Console.WriteLine($"Found {result.Hits.Count()} results...");

            return result.Hits.First().Source;
        }

        public void UpdateUser(Models.User model)
        {
            var result = _client.Update<Models.User>(model.Id.ToString(), item => item.Index(Storage.UserIndex).Doc(model).Refresh());

            Console.WriteLine(result.ApiCall.Success
                ? $"Updated user: {model.UserName}"
                : $"Unable to update user: {model.UserName}");
        }

        public IEnumerable<ClaimModel> GetClaimsForEntity(string ownerId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(Storage.ClaimsAlias)
                    .Size(30)
                    .Query(query => query
                    .Bool(condition => condition
                        .Must(must => must
                            .Match(match => match
                                .Field(field => field.Owner)
                                .Query(ownerId))))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public void AddClaimForOwner(ClaimModel claim)
        {
            _client.Index(claim, p => p
                       .Index(Storage.ClaimIndex)
                       .Id(claim.Id.ToString())
                       .Refresh());
        }

        public void RemoveClaimFromOwner(Guid claimId)
        {
            _client.Delete(new DocumentPath<ClaimModel>(claimId)
                .Index(Storage.ClaimIndex), item => item.Refresh());
        }

        public void QueryMatchingServices(IEnumerable<string> options)
        {
            //var matchResult = _client.Search<ServiceModel>(search => search
            //    .Index(ServiceIndex)
            //    .Query(q => q
            //        .Bool(b => b
            //            .Should(sh =>
            //                sh.Match(mt1 => mt1.Field(f1 => f1.Handle).Query("js")) ||
            //                sh.Match(mt2 => mt2.Field(f2 => f2.Handle).Query("homeoffice"))
            //            ))).Sort(o => o.Ascending(p => p.Name)));

            var filters = options.Select(option => (Func<QueryContainerDescriptor<ServiceModel>, QueryContainer>)
                (filter => filter
                    .Match(match => match
                        .Field(field => field.Handle)
                        .Query(option))));

            var matchResult = _client.Search<ServiceModel>(search => search
                .Index(Storage.ServiceIndex)
                .Query(q => q
                    .Bool(b => b
                        .Should(filters))).Sort(o => o.Ascending(p => p.Name)));

            Console.WriteLine($"Found {matchResult.Hits.Count()} matching results");

            foreach (var hit in matchResult.Hits)
            {
                Console.WriteLine($"{hit.Source.Handle}");
            }
        }

        public void QueryClaims()
        {
            var userResult = _client.Search<Models.User>(search => search
                .Index(Storage.UserIndex)
                .Query(query => query
                    .Term(term => term
                        .Field(field => field.UserName)
                        .Value("andycorp"))));

            var orgResult = _client.Search<TenantModel>(search => search
                .Index(Storage.TenantIndex)
                .Query(query => query
                    .Bool(condition => condition
                        .Must(must => must
                            .Match(match => match
                                .Field(field => field.Id)
                                .Query(userResult.Hits.First().Source.TenantId))))));

            var filters = orgResult.Hits.First().Source.Claims.Select(claim => (Func<QueryContainerDescriptor<ServiceModel>, QueryContainer>)
                (filter => filter
                    .Match(match => match
                        .Field(field => field.Handle)
                        .Query(claim.Value))));

            var serviceResult = _client.Search<ServiceModel>(search => search
                .Index(Storage.ServiceIndex)
                .Query(q => q
                    .Bool(b => b
                        .Should(filters))).Sort(o => o.Ascending(p => p.Name)));

            foreach (var hit in serviceResult.Hits)
            {
                if (hit.Source.Rights != null)
                {
                    foreach (var claim in hit.Source.Rights)
                    {
                        Console.WriteLine($"{hit.Source.Handle}:{claim}");
                    }
                }
            }
        }

        public void PrintCounts()
        {
            //var userCount = _client.Count<Models.User>(search => search
            //    .Index(Storage.UserIndex));

            //var orgCount = _client.Count<TenantModel>(search => search
            //    .Index(Storage.TenantIndex));

            //var appCount = _client.Count<ServiceModel>(search => search
            //    .Index(Storage.ServiceIndex));

            //var jointCount = _client.Count<ServiceModel>(search => search
            //    .Index(Indices.Parse($"{Storage.UserIndex}, {Storage.TenantIndex}, {Storage.ServiceIndex}")));

            var claimCount = _client.Count<ClaimModel>(search => search
                .Index(Storage.ClaimsAlias));

            //Console.WriteLine($"Users: {userCount.Count}");
            //Console.WriteLine($"Tenant: {orgCount.Count}");
            //Console.WriteLine($"Service: {appCount.Count}");
            //Console.WriteLine($"Total: {jointCount.Count}");

            Console.WriteLine($"Users: {claimCount.Count}");
        }

        public void ReIndex()
        {
            const string newIndex = "cx_demo_claims_2";
            var reindex =
                _client.Reindex<ClaimModel>(Storage.ClaimIndex, newIndex, (inbox => inbox
                    .Query(query => query.MatchAll())
                    .Scroll("10s")
                    .CreateIndex(index => index
                        .Mappings(ms => ms
                            .Map<ClaimModel>(m => m.AutoMap()
                                .Properties(prop => prop
                                    .String(field => field
                                        .Name(name => name.Id)
                                        .Index(FieldIndexOption.NotAnalyzed))
                                    .String(field => field
                                        .Name(name => name.Owner)
                                        .Index(FieldIndexOption.NotAnalyzed))
                                    .String(field => field
                                        .Name(name => name.Type)
                                        .Index(FieldIndexOption.NotAnalyzed))
                                    .String(field => field
                                        .Name(name => name.Value)
                                        .Index(FieldIndexOption.No))
                                    .Number(field => field
                                        .Name(name => name.Code)
                                        .Index(NonStringIndexOption.No))
                                    .Number(field => field
                                        .Name(name => name.Size)
                                        .Index(NonStringIndexOption.No))
                                    .Number(field => field
                                        .Name(name => name.Origin)
                                        .Index(NonStringIndexOption.No))))))));

            var observer = new ReindexObserver<ClaimModel>(onNext: response =>
            {
                Console.WriteLine($"Indexing document: {response.IsValid}");
            }, onError: error =>
            {
                Console.WriteLine($"Document error occured: {error.Message}");
            },
            completed: () =>
            {
                Console.WriteLine($"Document re-index");
            });

            reindex.Subscribe(observer);

            _client.DeleteIndex(Indices.Index(new IndexName {Name = Storage.ClaimIndex}));
            _client.Alias(x => x.Add(a => a.Alias(Storage.ClaimsAlias).Index(newIndex)));
        }
    }
}
