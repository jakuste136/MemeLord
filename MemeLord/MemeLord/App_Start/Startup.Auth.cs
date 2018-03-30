using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MemeLord.Configuration;
using MemeLord.Logic.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace MemeLord
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),

                AccessTokenExpireTimeSpan = AuthorizationConfiguration.TokenLifeTime,
                AllowInsecureHttp = true,
                Provider = GlobalConfiguration.Configuration.DependencyResolver.GetRootLifetimeScope()
                    .Resolve<OAuthAppProvider>()
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}