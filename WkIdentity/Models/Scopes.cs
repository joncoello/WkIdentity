using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WkIdentity.Models {
    static class Scopes {
        public static List<Scope> Get() {
            return new List<Scope>
            {
                 new Scope
                {
                    Name = "api1",

                    DisplayName = "Access to API",
                    Description = "This will grant you access to the API",
                    
                    Type = ScopeType.Resource,

                },

                StandardScopes.OpenId,
                StandardScopes.Profile,
            
                // additional
                StandardScopes.Email

            };
        }
    }
}