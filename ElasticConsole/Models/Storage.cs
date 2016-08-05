using System;
using System.Collections.Generic;

namespace ElasticConsole.Models
{
    internal static class Storage
    {
        internal static readonly Guid HsbcId = Guid.Parse("{B21D76EE-4EE2-459C-B40D-DDA1D5AD68EB}");
        internal static readonly Guid NissanId = Guid.Parse("{CE1C55FB-C4E6-45FA-8E5B-17BF18845CD0}");
        internal static readonly Guid FordId = Guid.Parse("{B31E7FC8-07E7-4092-AF4E-96421FE762A0}");

        internal static readonly Guid JavascriptId = Guid.Parse("{61C15BDA-713B-4DEE-B492-69593565F278}");
        internal static readonly Guid CommandLineId = Guid.Parse("{F6155E45-3A35-4402-8B35-0537ACED20AD}");
        internal static readonly Guid WebApiId = Guid.Parse("{5F3D6950-4A1E-4B52-93B2-8D658FCA0354}");
        internal static readonly Guid AnonymousId = Guid.Parse("{F0FAB524-F422-420E-971D-D5F013C2E392}");

        internal const string ServiceClaim = "passport_service";
        internal const string ServiceAdminClaim = "service_admin";
        internal const string ServiceCreatorClaim = "service_content_creator";
        internal const string ServiceUserClaim = "service_content_user";

        internal static List<ServiceModel> Services()
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

        internal static List<OrganisationModel> Tenants()
        {
            var store = new List<OrganisationModel>
            {
                new OrganisationModel
                {
                    Id = HsbcId,
                    Name = "HSBC",
                    Claim = "hsbc",
                    IsActive = true,
                    UserCount = 150
                },
                new OrganisationModel
                {
                    Id = NissanId,
                    Name = "Nissan",
                    Claim = "nissan",
                    IsActive = true,
                    UserCount = 250
                },
                new OrganisationModel
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

        internal static List<UserModel> Users()
        {
            var store = new List<UserModel>();

            for (var position = 1; position < 31; position++)
            {
                var orgId = Guid.Empty;

                if (position%3 == 0)
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

                store.Add(new UserModel
                {
                    Id = Guid.NewGuid(),
                    OrganisationId = orgId,
                    Email = $"user{position}@email.com",
                    UserName = $"user{position}"
                });
            }

            return store;
        }

        internal static List<ClaimModel> Claims()
        {
            var store = new List<ClaimModel>();
            FillClaims(store, ServiceClaim);
            FillClaims(store, ServiceAdminClaim);
            FillClaims(store, ServiceCreatorClaim);
            FillClaims(store, ServiceUserClaim);

            store.Add(new ClaimModel
            {
                Id = Guid.NewGuid(),
                Owner = AnonymousId,
                Type = ServiceClaim,
                Value = $"{ServiceClaim}_claim_anon"
            });

            FillClaims(store, ServiceClaim, "java", new List<Guid> {HsbcId, NissanId});
            FillClaims(store, ServiceClaim, "cli", new List<Guid> {FordId, HsbcId});
            FillClaims(store, ServiceClaim, "web", new List<Guid> {FordId});
            FillClaims(store, ServiceClaim, "anon", new List<Guid> {HsbcId, NissanId, FordId});

            return store;
        }

        private static void FillClaims(ICollection<ClaimModel> store, string type)
        {
            for (var position = 0; position < 3; position++)
            {
                var ownerId = Guid.Empty;
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
                    Id = Guid.NewGuid(),
                    Owner = ownerId,
                    Type = type,
                    Value = claimValue
                });
            }
        }

        private static void FillClaims(ICollection<ClaimModel> store, string type, string benafactor, IEnumerable<Guid> beneficiaries)
        {
            foreach (var owner in beneficiaries)
            {
                store.Add(new ClaimModel
                {
                    Id = Guid.NewGuid(),
                    Owner = owner,
                    Type = type,
                    Value = $"{type}_claim_{benafactor}"
                });
            }
        }
    }
}
