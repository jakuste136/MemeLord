using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class GoogleApiConfiguration
    {
        public static string ClientId => GoogleApiSettings.Default.client_id;
        public static string ProjectId => GoogleApiSettings.Default.project_id;
        public static string AuthUri => GoogleApiSettings.Default.auth_uri;
        public static string TokenUri => GoogleApiSettings.Default.token_uri;
        public static string AuthProvier => GoogleApiSettings.Default.auth_provider_x509_cert_url;
        public static string ClientSecret => GoogleApiSettings.Default.client_secret;
        public static string RedirectUri => GoogleApiSettings.Default.redirect_uris;
    }
}