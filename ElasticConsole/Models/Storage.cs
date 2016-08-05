using System;
using System.Collections.Generic;

namespace ElasticConsole.Models
{
    internal static class Storage
    {
        internal static List<ClientModel> Clients()
        {
            var store = new List<ClientModel>
            {
                new ClientModel
                {
                    Id = Guid.NewGuid(),
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
                new ClientModel
                {
                    Id = Guid.NewGuid(),
                    IsDisabled = false,
                    Name = "HTML Client",
                    Handle = "js.tokenmanager",
                    Type = ClientType.Javascript,

                    LoginRedirectLinks = new List<string>
                    {
                        "http://localhost:5000/oidc-client-sample.html",
                        "http://localhost:5000/oidc-client-sample-callback.html",
                        "http://localhost:5000/user-manager-sample.html",
                        "http://localhost:5000/user-manager-sample-popup.html",
                        "http://localhost:5000/user-manager-sample-silent.html",
                        "http://localhost:5000/user-manager-sample-callback.html"
                    },
                    LogoutRedirectLinks = new List<string>
                    {
                        "http://localhost:5000/index.html"
                    },
                    TrustedDomains = new List<string>
                    {
                        "http://localhost:5000"
                    },
                    RequiresAllGrants = true
                },
                new ClientModel
                {
                    Id = Guid.NewGuid(),
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
                new ClientModel
                {
                    Id = Guid.NewGuid(),
                    Name = "CLI Client Id",
                    Handle = "commandlineid",
                    IsDisabled = false,
                    Type = ClientType.Login,

                    Secrets = new List<string>
                    {
                        "21B5F798-BE55-42BC-8AA8-0025B903DC3B"
                    },

                    Grants = new List<string>
                    {
                        "api"
                    }
                },
                new ClientModel
                {
                    Id = Guid.NewGuid(),
                    Name = "MVC OWIN Implicit Client",
                    Handle = "mvc.owin.implicit",
                    Type = ClientType.WebApp,
                    Grants = new List<string>
                    {
                        "api"
                    },
                    LoginRedirectLinks = new List<string>
                    {
                        "https://localhost:44301/"
                    },

                    LogoutRedirectLinks = new List<string>
                    {
                        "https://localhost:44301/Home/SignoutCleanup"
                    }
                },
                new ClientModel
                {
                    Id = Guid.NewGuid(),
                    Name = "MVC OWIN Hybrid Client",
                    Handle = "mvc.owin.hybrid",
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
                    LoginRedirectLinks = new List<string>
                    {
                        "https://localhost:44300/"
                    },

                    LogoutRedirectLinks = new List<string>
                    {
                        "https://localhost:44300/",
                        "https://localhost:44300/Home/OidcSignOut"
                    }
                },
                new ClientModel
                {
                    Id = Guid.NewGuid(),
                    Name = "OpenID Connect without Client Library Sample",
                    Handle = "nolib.client",
                    Type = ClientType.Native,

                    Grants = new List<string>
                    {
                        "read",
                        "write",
                        "api"
                    },
                    LoginRedirectLinks = new List<string>
                    {
                        "http://localhost:11716/account/signInCallback"
                    }
                },
                new ClientModel
                {
                    Id = Guid.NewGuid(),
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
                new ClientModel
                {
                    Id = Guid.NewGuid(),
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

        private static List<OrganisationModel> Tenants()
        {
            var store = new List<OrganisationModel>
            {
                new OrganisationModel
                {
                    Id = Guid.NewGuid(),
                    Name = "HSBC",
                    Claim = "hsbc",
                    IsActive = true,
                    UserCount = 150
                },
                new OrganisationModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Nissan",
                    Claim = "nissan",
                    IsActive = true,
                    UserCount = 250
                },
                new OrganisationModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Ford",
                    Claim = "ford",
                    IsActive = false,
                    UserCount = 50
                }
            };

            return store;
        }
    }
}
