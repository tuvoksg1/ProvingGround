using System;
using System.Collections.Generic;
using ElasticConsole.Models;
using Nest;
using User = ElasticConsole.Models.User;

namespace ElasticConsole.Data
{
    public class Storage
    {
        private const string DefaultIndex = "cx_demo";
        internal const string ServiceIndex = "cx_demo_apps";
        internal const string UserIndex = "cx_demo_users";
        internal const string ClaimIndex = "cx_demo_claims_1";
        internal const string TenantIndex = "cx_demo_tenants";
        internal const string ClaimsAlias = "ClaimsIndex";

        internal static readonly string HsbcId = Guid.Parse("{B21D76EE-4EE2-459C-B40D-DDA1D5AD68EB}").ToString();
        internal static readonly string NissanId = Guid.Parse("{CE1C55FB-C4E6-45FA-8E5B-17BF18845CD0}").ToString();
        internal static readonly string FordId = Guid.Parse("{B31E7FC8-07E7-4092-AF4E-96421FE762A0}").ToString();

        internal static readonly string JavascriptId = Guid.Parse("{61C15BDA-713B-4DEE-B492-69593565F278}").ToString();
        internal static readonly string CommandLineId = Guid.Parse("{F6155E45-3A35-4402-8B35-0537ACED20AD}").ToString();
        internal static readonly string WebApiId = Guid.Parse("{5F3D6950-4A1E-4B52-93B2-8D658FCA0354}").ToString();
        internal static readonly string AnonymousId = Guid.Parse("{F0FAB524-F422-420E-971D-D5F013C2E392}").ToString();

        internal static readonly string TestUserId = Guid.Parse("{D3924469-2569-4BCF-B1B0-1115A7EF3414}").ToString();

        internal const string ServiceClaim = "passport_service";
        internal const string ServiceAdminClaim = "service_admin";
        internal const string ServiceCreatorClaim = "service_content_creator";
        internal const string ServiceUserClaim = "service_content_user";
        internal const string TenantClaim = "tenant_key";

        private readonly ElasticClient _client;

        public Storage(string serverUrl)
        {
            var passportIndices = new List<string> { ClaimIndex };

            var local = new Uri(serverUrl);
            var settings = new ConnectionSettings(local).DefaultIndex(DefaultIndex);
            _client = new ElasticClient(settings);

            var res = _client.LowLevel.ClusterHealth<object>();

            if (res.SuccessOrKnownError)
            {
                foreach (var index in passportIndices)
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
            else
            {
                throw new InvalidOperationException("Elastic search server is not reachable");
            }
        }

        public IElasticClient Connection => _client;

        private void InitialiseIndex(string index)
        {
            #region Applications

            if (index == ServiceIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof(ServiceModel)
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
                                    .Index(NonStringIndexOption.No))))));
            }

            #endregion

            #region Organisations

            if (index == TenantIndex)
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
                                    .Index(NonStringIndexOption.No))
                                .Nested<ClaimModel>(field => field.Name(child => child.Claims))))));
            }

            #endregion

            #region Users

            if (index == UserIndex)
            {
                _client.CreateIndex(new IndexName
                {
                    Name = index,
                    Type = typeof(User)
                }, ci => ci
                    .Mappings(ms => ms
                        .Map<User>(m => m.AutoMap()
                            .Properties(prop => prop
                                .Number(field => field
                                   .Name(name => name.AccessFailedCount)
                                   .Index(NonStringIndexOption.No))
                                .String(field => field
                                    .Name(name => name.Email)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .Boolean(field => field
                                    .Name(name => name.EmailConfirmed)
                                    .Index(NonStringIndexOption.No))
                                .String(field => field
                                    .Name(name => name.FirstName)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .String(field => field
                                    .Name(name => name.LastName)
                                    .Index(FieldIndexOption.NotAnalyzed))
                                .Boolean(field => field
                                    .Name(name => name.LockoutEnabled)
                                    .Index(NonStringIndexOption.No))
                                .Date(field => field
                                    .Name(name => name.LockoutEndDateUtc)
                                    .Index(NonStringIndexOption.No))
                                .String(field => field
                                    .Name(name => name.PasswordHash)
                                    .Index(FieldIndexOption.No))
                                .String(field => field
                                    .Name(name => name.PhoneNumber)
                                    .Index(FieldIndexOption.No))
                                .Boolean(field => field
                                    .Name(name => name.PhoneNumberConfirmed)
                                    .Index(NonStringIndexOption.No))
                                .String(field => field
                                    .Name(name => name.SecurityStamp)
                                    .Index(FieldIndexOption.No))
                                .String(field => field
                                    .Name(name => name.TenantId)
                                    .Index(FieldIndexOption.Analyzed))
                                .Boolean(field => field
                                    .Name(name => name.TwoFactorEnabled)
                                    .Index(NonStringIndexOption.No))
                                .String(field => field
                                    .Name(name => name.UserName)
                                    .Index(FieldIndexOption.Analyzed))
                                .Nested<ClaimModel>(field => field.Name(child => child.Claims))))));
            } 

            #endregion

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
                                    .Index(FieldIndexOption.No)))))
                    .Aliases(als => als.Alias(ClaimsAlias)));
            }

            Console.WriteLine($"{index} Index created");
            Console.WriteLine($"Populating {index} index....");

            AddDataToStorage(index);
        }

        private void AddDataToStorage(string index)
        {
            #region Applications

            if (index == ServiceIndex)
            {
                var items = Services();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} services indexed");
            }

            #endregion

            #region Organisations

            if (index == TenantIndex)
            {
                var items = Tenants();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} organisations indexed");
            }

            #endregion

            #region Users

            if (index == UserIndex)
            {
                var items = Users();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(index)
                        .Id(item.Id)
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} users indexed");
            } 

            #endregion

            if (index == ClaimIndex)
            {
                var items = TestClaims();

                foreach (var item in items)
                {
                    _client.Index(item, p => p
                        .Index(ClaimsAlias)
                        .Id(item.Id.ToString())
                        .Refresh());
                }

                Console.WriteLine($"{items.Count} claims indexed");
            }
        }

        private static List<ServiceModel> Services()
        {
            var store = new List<ServiceModel>
            {
                new ServiceModel
                {
                    Id = JavascriptId,
                    IsDisabled = false,
                    Name = "JS Client",
                    Handle = "js",
                    Type = ClientType.Javascript,

                    LoginRedirectLinks = new List<string>
                    {
                        "http://localhost:51631/popup.html",
                        "http://localhost:51631/index.html",
                        "http://localhost:51631/silent-renew.html"
                    },
                    LogoutRedirectLinks = new List<string>
                    {
                        "http://localhost:51631/index.html"
                    },
                    TrustedDomains = new List<string>
                    {
                        "http://localhost:51631"
                    },
                    RequiresAllGrants = true
                },
                new ServiceModel
                {
                    Id = CommandLineId,
                    Name = "CLI Client",
                    Handle = "commandline",
                    IsDisabled = false,
                    Type = ClientType.Console,

                    Secrets = new List<string>
                    {
                        "F621F470-9731-4A25-80EF-67A6F7C5F4B8"
                    },
                    Grants = new List<string>
                    {
                        "api"
                    }
                },
                new ServiceModel
                {
                    Id = WebApiId,
                    Name = "Home Office",
                    Handle = "homeoffice",
                    Type = ClientType.WebApp,

                    Secrets = new List<string>
                    {
                        "secret"
                    },
                    Grants = new List<string>
                    {
                        "openid",
                        "profile",
                        "email",
                        "roles",
                        "offline_access",
                        "read",
                        "write",
                        "api"
                    },
                    RequiresRefreshToken = true,

                    LoginRedirectLinks = new List<string>
                    {
                        "https://localhost:44308/"
                    },

                    LogoutRedirectLinks = new List<string>
                    {
                        "https://localhost:44308/"
                    },

                    //LogoutUri = "https://localhost:44308/Home/OidcSignOut"
                },
                new ServiceModel
                {
                    Id = AnonymousId,
                    Name = "Anonymous",
                    Handle = "anonymous",
                    IsDisabled = false,
                    Type = ClientType.Login,
                    Secrets = new List<string>
                    {
                        "3BD871BA-BD6E-4B65-971A-0C2559713BAD"
                    },
                    Grants = new List<string>
                    {
                        "read",
                        "write",
                        "api"
                    },
                    RequiresAllGrants = true
                }
            };

            return store;
        }

        private static List<TenantModel> Tenants()
        {
            var store = new List<TenantModel>
            {
                new TenantModel
                {
                    Id = HsbcId,
                    Name = "HSBC",
                    Claim = "hsbc",
                    IsActive = true,
                    UserCount = 150
                },
                new TenantModel
                {
                    Id = NissanId,
                    Name = "Nissan",
                    Claim = "nissan",
                    IsActive = true,
                    UserCount = 250
                },
                new TenantModel
                {
                    Id = FordId,
                    Name = "Ford",
                    Claim = "ford",
                    IsActive = false,
                    UserCount = 50
                }
            };

            return store;
        }

        private static List<User> Users()
        {
            var store = new List<User>();

            for (var position = 1; position < 31; position++)
            {
                var orgId = string.Empty;

                if (position % 3 == 0)
                {
                    orgId = HsbcId;
                }

                if (position % 3 == 1)
                {
                    orgId = FordId;
                }
                if (position % 3 == 2)
                {
                    orgId = NissanId;
                }

                store.Add(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    TenantId = orgId,
                    Email = $"user{position}@email.com",
                    UserName = $"user{position}",
                    FirstName = $"FirstName{position}",
                    LastName = $"LastName{position}",
                    Claims = new List<ClaimModel>()
                });
            }

            return store;
        }

        //private async static Task<List<Core.User>> GetExistingUsers()
        //{
        //    var store = new List<Core.User>();

        //    var userStore =
        //        new UserStore<Core.User, Core.Role>("Data Source=.;Initial Catalog=MR_UK_Pledge;Integrated Security=True");

        //    var index = 0;

        //    foreach (var dbUser in userStore.Users)
        //    {
        //        var claims = await userStore.GetClaimsAsync(dbUser);
        //        var roles = await userStore.GetRolesAsync(dbUser);

        //        dbUser.TenantId = GetTenantId(index++);
        //        dbUser.Claims = new List<ClaimModel>();

        //        foreach (var claim in claims)
        //        {
        //            dbUser.Claims.Add(new ClaimModel
        //            {
        //                Id = Guid.NewGuid().ToString(),
        //                Owner = dbUser.Id,
        //                Type = claim.Type,
        //                Value = claim.Value
        //            });
        //        }

        //        store.Add(dbUser);
        //    }

        //    return store;
        //}

        private static string GetTenantId(int index)
        {
            var orgId = string.Empty;

            if (index == 0)
            {
                orgId = HsbcId;
            }

            if (index == 1)
            {
                orgId = FordId;
            }
            if (index == 2)
            {
                orgId = NissanId;
            }

            return orgId;
        }

        private static List<ClaimModel> TestClaims()
        {
            var claims = new List<ClaimModel>();

            for (var index = 0; index < 15; index++)
            {
                claims.Add(new ClaimModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Owner = AnonymousId,
                    Type = ServiceClaim,
                    Size = index,
                    Code = $"{index}",
                    Value = $"{ServiceClaim}_claim_anon",
                    Origin = index == 0 ? ClientType.Mobile : ClientType.Console
                });
            }

            return claims;
        }

        private static List<ClaimModel> Claims()
        {
            var store = new List<ClaimModel>();
            FillClaims(store, ServiceClaim);
            FillClaims(store, ServiceAdminClaim);
            FillClaims(store, ServiceCreatorClaim);
            FillClaims(store, ServiceUserClaim);

            store.Add(new ClaimModel
            {
                Id = Guid.NewGuid().ToString(),
                Owner = AnonymousId,
                Type = ServiceClaim,
                Value = $"{ServiceClaim}_claim_anon"
            });

            FillClaims(store, ServiceClaim, "java", new List<string> { HsbcId, NissanId });
            FillClaims(store, ServiceClaim, "cli", new List<string> { FordId, HsbcId });
            FillClaims(store, ServiceClaim, "web", new List<string> { FordId });
            FillClaims(store, ServiceClaim, "anon", new List<string> { HsbcId, NissanId, FordId });

            store.Add(new ClaimModel
            {
                Id = Guid.NewGuid().ToString(),
                Owner = HsbcId,
                Type = TenantClaim,
                Value = "hsbc"
            });

            store.Add(new ClaimModel
            {
                Id = Guid.NewGuid().ToString(),
                Owner = NissanId,
                Type = TenantClaim,
                Value = "nissan"
            });

            store.Add(new ClaimModel
            {
                Id = Guid.NewGuid().ToString(),
                Owner = FordId,
                Type = TenantClaim,
                Value = "ford"
            });

            return store;
        }

        private static void FillClaims(ICollection<ClaimModel> store, string type)
        {
            for (var position = 0; position < 3; position++)
            {
                var ownerId = string.Empty;
                var claimValue = string.Empty;

                if (position == 0)
                {
                    ownerId = JavascriptId;
                    claimValue = $"{type}_claim_java";
                }

                if (position == 1)
                {
                    ownerId = CommandLineId;
                    claimValue = $"{type}_claim_cli";
                }

                if (position == 2)
                {
                    ownerId = WebApiId;
                    claimValue = $"{type}_claim_web";
                }

                store.Add(new ClaimModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Owner = ownerId,
                    Type = type,
                    Value = claimValue
                });
            }
        }

        private static void FillClaims(ICollection<ClaimModel> store, string type, string benafactor, IEnumerable<string> beneficiaries)
        {
            foreach (var owner in beneficiaries)
            {
                store.Add(new ClaimModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Owner = owner,
                    Type = type,
                    Value = $"{type}_claim_{benafactor}"
                });
            }
        }
    }
}
