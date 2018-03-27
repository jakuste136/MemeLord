using System.Configuration;
using System.Reflection;
using DbUp;
using MemeLord.Configuration;

namespace MemeLord
{
    public static class MigrationRunner
    {
        public static void RunMigrations()
        {
            if (MigrationsConfiguration.RunMigrationsOnBuild)
                ExecuteMigrations();
        }

        private static void ExecuteMigrations()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MemeLordDb"].ConnectionString;

            var upgrader = DeployChanges.To.SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}