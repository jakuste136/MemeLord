using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class AuthenticationConfiguration
    {
        public int SaltSize => AuthenticationSettings.Default.SaltSize;
        public int HashSize => AuthenticationSettings.Default.HashSize;
        public int Iterations => AuthenticationSettings.Default.Iterations;
        public string HashPrefix => AuthenticationSettings.Default.HashPrefix;
        public string HashVersion => AuthenticationSettings.Default.HashVersion;
    }
}