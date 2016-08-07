using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WkResource {

    public class Startup {

        public void Configuration(IAppBuilder app) {

            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {

                Authority = "http://wkidentity.azurewebsites.net/",

                //ValidationMode = ValidationMode.ValidationEndpoint,

                ClientId = "js",
                ClientSecret = "api-secret",

                RequiredScopes = new[] { "api1" }
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }

    }
}