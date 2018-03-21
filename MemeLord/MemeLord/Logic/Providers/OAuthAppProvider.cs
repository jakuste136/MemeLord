using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Queries;
using MemeLord.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace MemeLord.Logic.Providers
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        /*
         * Validate client token request
         */
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            //if (context.TryGetFormCredentials(out var clientId, out var clientSecret))
            {
                // validation of client
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        /*
         * Validate user to acquire token
         */
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // TODO: [Mateusz] Cleanup
            return Task.Factory.StartNew(() =>
            {
                var user = new UserQueries().GetUserByCredentials(context.UserName);
                if (user != null && HashManager.Verify(context.Password, user.Hash))
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            //new Claim("UserID", user.Username)
                        };

                    var oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Invalid credentials");
                }
            });
        }

        
    }
}