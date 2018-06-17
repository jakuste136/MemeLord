using System;
using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class AuthorizationConfiguration
    {
        public static TimeSpan TokenLifeTime => AuthorizationSettings.Default.TokenLifeTime;
        public static string Audience => AuthorizationSettings.Default.Audience;
        public static string Issuer => AuthorizationSettings.Default.Issuer;
        public static string Secret => AuthorizationSettings.Default.Secret;
    }
}