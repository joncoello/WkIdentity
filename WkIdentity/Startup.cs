using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.InMemory;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using WkIdentity.Models;

namespace WkIdentity {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            app.UseIdentityServer(new IdentityServerOptions {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),

                RequireSsl = false,

                Factory = new IdentityServerServiceFactory()
                   .UseInMemoryUsers(Users.Get())
                   .UseInMemoryClients(Clients.Get())
                   .UseInMemoryScopes(Scopes.Get())


            });

        }

        X509Certificate2 LoadCertificate() {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"idsrv3test.pfx"), "idsrv3test");
        }

    }
}