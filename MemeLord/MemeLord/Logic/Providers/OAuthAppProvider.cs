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
                    // TODO Mateusz: ROLE PLACEHOLDER
                    const string role = "User";

                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Role, role),
                        };

                    var authenticationProperties = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { "role", role },
                    });

                    var oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, authenticationProperties));
                }
                else
                {
                    context.SetError("invalid_grant", "Invalid credentials");
                }
            });
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