using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MemeLord.Configuration;
using MemeLord.Logic.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace MemeLord
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }
        public static GoogleOAuth2AuthenticationOptions GoogleOptions { get; set; }

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

            GoogleOptions = new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "GoogleAuth",
                
                ClientId = GoogleApiConfiguration.ClientId,
                ClientSecret = GoogleApiConfiguration.ClientSecret,
                CallbackPath = new PathString("/signin-google"),
                Provider = GlobalConfiguration.Configuration.DependencyResolver.GetRootLifetimeScope()
                    .Resolve<GoogleAuthenticationProvider>()
            };
            GoogleOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.SetDefaultSignInAsAuthenticationType("GoogleAuth");

            app.UseGoogleAuthentication(GoogleOptions);

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}