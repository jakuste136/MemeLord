using MemeLord.Configuration;
using MemeLord.DataObjects.Response;

namespace MemeLord.Logic.Modules.Authentication
{
    public interface IGoogleAuthenticationModule
    {
        GetGoogleRedirectUriRespose GetRedirectUri(string callbackUri);
    }

    public class GoogleAuthenticationModule : IGoogleAuthenticationModule
    {
        public GetGoogleRedirectUriRespose GetRedirectUri(string callbackUri)
        {
            var authUri = GoogleApiConfiguration.AuthUri;
            var clientId = GoogleApiConfiguration.ClientId;
            return new GetGoogleRedirectUriRespose
            {
                Uri = $"{authUri}?redirect_uri={callbackUri}&response_type=token&client_id={clientId}&scope=profile"
            };
        }
    }
}