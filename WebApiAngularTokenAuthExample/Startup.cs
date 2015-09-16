using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(WebApiAngularTokenAuthExample.Startup))]

namespace WebApiAngularTokenAuthExample
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // Note: Remove the following line before you deploy to production:
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            app.UseWebApi(config);
        }
    }
}
