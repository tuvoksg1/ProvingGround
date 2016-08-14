using System;
using System.Collections.Generic;
using System.Linq;
using ElasticConsole.Models;
using Nest;

namespace ElasticConsole.Data
{
    internal class Repository
    {
        private const string DefaultIndex = "cx_passport";
        private const string ServiceIndex = "cx_passport_apps";
        private const string UserIndex = "cx_passport_users";
        private const string ClaimIndex = "cx_passport_claims";
        private const string OrgIndex = "cx_passport_tenants";
        private readonly List<string> _passportIndices;
        private ElasticClient _client;

        public Repository()
        {
            _passportIndices = new List<string> {ServiceIndex, UserIndex, ClaimIndex, OrgIndex};
            InitialiseConnection();
        }

        private void InitialiseConnection()
        {
            var local = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(local).DefaultIndex(DefaultIndex);
            _client = new ElasticClient(settings);

            var res = _client.LowLevel.ClusterHealth<object>();

            Console.WriteLine(res.SuccessOrKnownError);

            foreach (var index in _passportIndices)
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
            }  
        }

        private void InitialiseIndex(string index)
        {
            if (index == ServiceIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof (ServiceModel)
                }, ci => ci
                    .Mappings(ms => ms
                        .Map<ServiceModel>(m => m.AutoMap()
                            .Properties(prop => prop
                                .String(field => field
                                    .Name(name => name.Handle)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.Name)
                                    .Index(FieldIndexOption.NotAnalyzed))
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
                                    .Index(NonStringIndexOption.No))))
                    ));
            }

            if (index == OrgIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof(TenantModel)
                }, ci => ci
                    .Mappings(ms => ms
                        .Map<TenantModel>(m => m.AutoMap()
                            .Properties(prop => prop
                                .String(field => field
                                    .Name(name => name.Claim)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.Name)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .Boolean(field => field
                                    .Name(name => name.IsActive)
                                    .Index(NonStringIndexOption.No))
                                .Number(field => field
                                    .Name(name => name.UserCount)
                                    .Index(NonStringIndexOption.No))))
                    ));
            }

            if (index == UserIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof (Models.User)
                }, ci => ci
                    .Mappings(ms => ms
                        .Map<Models.User>(m => m.AutoMap()
                            .Properties(prop => prop
                                .String(field => field
                                    .Name(name => name.Email)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.UserName)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.TenantId)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                    .Nested<ClaimModel>(field => field.Name(child => child.Claims))))));
            }

            if (index == ClaimIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof(ClaimModel)
                }, ci => ci
                    .Mappings(ms => ms
                        .Map<ClaimModel>(m => m.AutoMap()
                            .Properties(prop => prop
                                .String(field => field
                                    .Name(name => name.Owner)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.Type)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.Value)
                                    .Index(FieldIndexOption.No))))
                    ));
            }

            Console.WriteLine($"{index} Index created");
            Console.WriteLine($"Populating {index} index....");

            AddDataToStorage(index);
        }

        private void AddDataToStorage(string index)
        {
            if (index == ServiceIndex)
            {
                var items = Storage.Services();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} services indexed");
            }

            if (index == OrgIndex)
            {
                var items = Storage.Tenants();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} organisations indexed");
            }

            if (index == UserIndex)
            {
                var items = Storage.Users();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} users indexed");
            }

            if (index == ClaimIndex)
            {
                var items = Storage.Claims();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} claims indexed");
            }
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

        public IEnumerable<Models.User> GetUsersForOrganisation(Guid orgId)
        {
            var matchResult = _client.Search<Models.User>(search =>
                search.Index(UserIndex)
                    .Query(query => query.Term(term =>
                        term.Field(field => field.TenantId)
                            .Value(orgId.ToString())))
                            .Sort(sort => sort.Ascending(field => field.UserName)));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<Models.User>();
        }

        public IEnumerable<ClaimModel> GetClaimsForOrganisation(Guid orgId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(ClaimIndex)
                    .Query(query => query.Term(term => term
                        .Field(field => field.Owner)
                        .Value(orgId.ToString()))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public IEnumerable<ClaimModel> GetClaimsForService(Guid serviceId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(ClaimIndex)
                    .Query(query => query.Term(term => term
                        .Field(field => field.Owner)
                        .Value(serviceId.ToString()))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public Models.User FindUser(string userName)
        {
            var result = _client.Search<Models.User>(search => search
                .Index(UserIndex)
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
            var result = _client.Update<Models.User>(model.Id.ToString(), item => item.Index(UserIndex).Doc(model).Refresh());

            Console.WriteLine(result.ApiCall.Success
                ? $"Updated user: {model.UserName}"
                : $"Unable to update user: {model.UserName}");
        }

        public IEnumerable<ClaimModel> GetClaimsForEntity(Guid ownerId)
        {
            var matchResult = _client.Search<ClaimModel>(search =>
                search.Index(ClaimIndex)
                    .Query(query => query.Term(term => term
                        .Field(field => field.Owner)
                        .Value(ownerId.ToString()))));

            return matchResult.ApiCall.Success ? matchResult.Hits.Select(arg => arg.Source) : new List<ClaimModel>();
        }

        public void AddClaimForOwner(ClaimModel claim)
        {
            _client.Index(claim, p => p
                       .Index(ClaimIndex)
                       .Id(claim.Id.ToString())
                       .Refresh());
        }

        public void RemoveClaimFromOwner(Guid claimId)
        {
            _client.Delete(new DocumentPath<ClaimModel>(claimId)
                .Index(ClaimIndex), item => item.Refresh());
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
                .Index(ServiceIndex)
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
                .Index(UserIndex)
                .Query(query => query
                    .Term(term => term
                        .Field(field => field.UserName)
                        .Value("andycorp"))));

            var orgResult = _client.Search<TenantModel>(search => search
                .Index(OrgIndex)
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
                .Index(ServiceIndex)
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
            var userCount = _client.Count<Models.User>(search => search
                .Index(UserIndex));

            var orgCount = _client.Count<TenantModel>(search => search
                .Index(OrgIndex));

            var appCount = _client.Count<ServiceModel>(search => search
                .Index(ServiceIndex));

            var jointCount = _client.Count<ServiceModel>(search => search
                .Index(Indices.Parse($"{UserIndex}, {OrgIndex}, {ServiceIndex}")));

            Console.WriteLine($"Users: {userCount.Count}");
            Console.WriteLine($"Tenant: {orgCount.Count}");
            Console.WriteLine($"Service: {appCount.Count}");
            Console.WriteLine($"Total: {jointCount.Count}");
        }
    }
}
