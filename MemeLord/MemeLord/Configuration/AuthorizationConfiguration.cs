using System;
using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class AuthorizationConfiguration
    {
        public static TimeSpan TokenLifeTime => AuthorizationSettings.Default.TokenLifeTime;
    }
}