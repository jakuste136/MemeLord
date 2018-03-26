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
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim("role", "user"),
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