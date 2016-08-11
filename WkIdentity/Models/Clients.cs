using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WkIdentity.Models {
    static class Clients {

        private const string JS_CLIENT_ADDRESS = "http://localhost:55473";
        //private const string JS_CLIENT_ADDRESS = "http://wkjsclient.azurewebsites.net";

        public static List<Client> Get() {
            return new List<Client>
            {
                // no human involved
                new Client
                {
                    ClientName = "Silicon-only Client",
                    ClientId = "silicon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                },

                // human is involved
                new Client {
                    ClientName = "Silicon on behalf of Carbon Client",
                    ClientId = "carbon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    Flow = Flows.ResourceOwner,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                },

                 // implicit
                new Client {
                    ClientName = "implicit Client",
                    ClientId = "implicit",
                    Enabled = true,

                    Flow = Flows.Implicit,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("21B5F798-BE55-42BC-8AA8-0025B903DC3Z".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                },

                new Client
                {
                    Enabled = true,
                    ClientName = "JS Client",
                    ClientId = "js",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        JS_CLIENT_ADDRESS + "/popup.html"
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        JS_CLIENT_ADDRESS
                    },

                    AllowAccessToAllScopes = true,

                    AllowedScopes = new List<string>
                    {
                        "openid", "profile", "email", "api1"
                    }

                }

            };
        }
    }
}