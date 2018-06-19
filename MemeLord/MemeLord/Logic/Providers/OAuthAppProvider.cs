using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Repository;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace MemeLord.Logic.Providers
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly HashManager _hashManager;

        public OAuthAppProvider(IUserRepository userRepository, HashManager hashManager)
        {
            _userRepository = userRepository;
            _hashManager = hashManager;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // TODO Mateusz: CLIENT TOKEN VALIDATION IS NOT USED AT THIS TIME, ADD LATER

            if (context.ClientId == null)
            //if (context.TryGetFormCredentials(out var clientId, out var clientSecret))
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var user = _userRepository.GetUserByCredentials(context.UserName);
                if (user != null && _hashManager.Verify(context.Password, user.Hash))
                {
                    if (user.BannedDate > DateTime.Now)
                    {
                        context.SetError("invalid_grant", "User is banned");
                    }
                    else
                    {
                        var role = _userRepository.GetUserRoleByUserId(user.Id);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Role, role?.Name ?? ""),
                        };

                        var authenticationProperties = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            { "role", role?.Name ?? "" },
                        });

                        var oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                        context.Validated(new AuthenticationTicket(oAutIdentity, authenticationProperties));
                    }
                    
                }
                else
                {
                    context.SetError("invalid_grant", "Invalid credentials");
                }
            });
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == null)
                return Task.FromResult<object>(null);
            var expectedRootUri = new Uri(context.Request.Uri, "/login");

            if (expectedRootUri.AbsoluteUri == context.RedirectUri)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}