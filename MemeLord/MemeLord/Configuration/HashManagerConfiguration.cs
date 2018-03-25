using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public static class HashManagerConfiguration
    {
        public static int SaltSize => HashManagerSettings.Default.SaltSize;
        public static int HashSize => HashManagerSettings.Default.HashSize;
        public static int Iterations => HashManagerSettings.Default.Iterations;
        public static string HashPrefix => HashManagerSettings.Default.HashPrefix;
    }
}