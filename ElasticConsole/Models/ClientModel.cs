using System;
using System.Collections.Generic;

namespace ElasticConsole.Models
{
    /// <summary>
    /// Storage model for ID3 Clients
    /// </summary>
    public class ClientModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the handle.
        /// </summary>
        /// <value>
        /// The handle.
        /// </value>
        public string Handle { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is disabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisabled { get; set; }
        /// <summary>
        /// Gets or sets the client type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public ClientType Type { get; set; }
        /// <summary>
        /// Gets or sets the grants that identify the scope models to load for this client.
        /// </summary>
        /// <value>
        /// The grants.
        /// </value>
        public List<string> Grants { get; set; }
        /// <summary>
        /// Gets or sets the known secrets for this client.
        /// </summary>
        /// <value>
        /// The secrets.
        /// </value>
        public List<string> Secrets { get; set; }
        /// <summary>
        /// Gets or sets the rights that identify the claim models to load for this client.
        /// </summary>
        /// <value>
        /// The rights.
        /// </value>
        public List<string> Rights { get; set; }
        /// <summary>
        /// Gets or sets the trusted domains for which CORS should be enabled.
        /// </summary>
        /// <value>
        /// The trusted domains.
        /// </value>
        public List<string> TrustedDomains { get; set; }
        /// <summary>
        /// Gets or sets the login redirect links.
        /// </summary>
        /// <value>
        /// The login redirect links.
        /// </value>
        public List<string> LoginRedirectLinks { get; set; }
        /// <summary>
        /// Gets or sets the logout redirect links.
        /// </summary>
        /// <value>
        /// The logout redirect links.
        /// </value>
        public List<string> LogoutRedirectLinks { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the client requires all grants.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the requires all grants; otherwise, <c>false</c>.
        /// </value>
        public bool RequiresAllGrants { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this client requires refresh tokens.
        /// </summary>
        /// <value>
        /// <c>true</c> if the client requires refresh tokens; otherwise, <c>false</c>.
        /// </value>
        public bool RequiresRefreshToken { get; set; }

        public List<string> GetList(string name)
        {
            switch (name)
            {
                case "Login":
                    return LoginRedirectLinks ?? new List<string>();
                case "Logout":
                    return LogoutRedirectLinks ?? new List<string>();
                case "Domains":
                    return TrustedDomains ?? new List<string>();
                case "Secrets":
                    return Secrets ?? new List<string>();
                case "Rights":
                    return Rights ?? new List<string>();
                default:
                    return new List<string>();
            }
        }

        public void SetList(string name, List<string> content)
        {
            if (name == "Login")
            {
                LoginRedirectLinks = content;
            }

            if (name == "Logout")
            {
                LogoutRedirectLinks = content;
            }

            if (name == "Domains")
            {
                TrustedDomains = content;
            }

            if (name == "Secrets")
            {
                Secrets = content;
            }

            if (name == "Rights")
            {
                Rights = content;
            }
        }
    }
}
