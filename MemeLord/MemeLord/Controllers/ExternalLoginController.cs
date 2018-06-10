using System.Web.Http;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Modules.Authentication;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/externalLogin")]
    public class ExternalLoginController : ApiController
    {
        private readonly IGoogleAuthenticationModule _googleAuthenticationModule;

        public ExternalLoginController(IGoogleAuthenticationModule googleAuthenticationModule)
        {
            _googleAuthenticationModule = googleAuthenticationModule;
        }

        [HttpGet]
        public GetGoogleRedirectUriRespose GetRedirectUri()
        {
            var returnUrl = "https://localhost:44372/signin-google";
            return _googleAuthenticationModule.GetRedirectUri(returnUrl);
        }
    }
}