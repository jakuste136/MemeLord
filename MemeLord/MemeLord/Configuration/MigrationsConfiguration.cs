using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public static class MigrationsConfiguration
    {
        public static bool RunMigrationsOnBuild => MigrationSettings.Default.RunMigrationsOnBuild;
    }
}