using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;

namespace NancySelfHost.Entities
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "implicitclient",
                    ClientName = "Example Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris =
                        new List<string> {"https://localhost:44304/account/signInCallback"},
                    PostLogoutRedirectUris =
                        new List<string> {"https://localhost:44304/"},
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email
                    },
                    AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }

    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope> {
            StandardScopes.OpenId,
            StandardScopes.Profile,
            StandardScopes.Email,
            StandardScopes.Roles,
            StandardScopes.OfflineAccess
        };
        }
    }

    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser> {
            new InMemoryUser {
                Subject = "1",
                Username = "folacorp",
                Password = "Fola@1234",
                Claims = new List<Claim> {
                    new Claim(Constants.ClaimTypes.GivenName, "Scott"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Brady"),
                    new Claim(Constants.ClaimTypes.Email, "info@scottbrady91.com"),
                    new Claim(Constants.ClaimTypes.Role, "Badmin")
                }
            }
        };
        }
    }

    static class Certificate
    {
        public static X509Certificate2 Get()
        {
            var assembly = typeof(Certificate).Assembly;
            using (var stream = assembly.GetManifestResourceStream("NancySelfHost.Entities.idsrv3test.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
