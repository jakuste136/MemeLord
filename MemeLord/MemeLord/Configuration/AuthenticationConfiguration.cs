using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static int SaltSize => AuthenticationSettings.Default.SaltSize;
        public static int HashSize => AuthenticationSettings.Default.HashSize;
        public static int Iterations => AuthenticationSettings.Default.Iterations;
        public static string HashPrefix => AuthenticationSettings.Default.HashPrefix;
    }
}