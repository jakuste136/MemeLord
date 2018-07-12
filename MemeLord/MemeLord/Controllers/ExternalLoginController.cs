using System;
using System.IO;
using System.Net;
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

        [Route("callback")]
        [HttpGet]
        public GetGoogleRedirectUriRespose Callback()
        {
            Console.Write("Fuck you owin");
            return new GetGoogleRedirectUriRespose();
        }

        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}