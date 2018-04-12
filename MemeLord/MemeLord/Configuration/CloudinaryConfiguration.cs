using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class CloudinaryConfiguration
    {
        public string CloudName => CloudinarySettings.Default.CloudName;
        public string ApiKey => CloudinarySettings.Default.ApiKey;
        public string ApiSecret => CloudinarySettings.Default.ApiSecret;
    }
}