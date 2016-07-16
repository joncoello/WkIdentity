using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WkIdentity.Models;

namespace WkIdentity {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            var options = new IdentityServerOptions {
                Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),

                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}