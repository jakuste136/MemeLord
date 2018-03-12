using System.Reflection;
using DbUp;

namespace MemeLord
{
    public static class MigrationRunner
    {
        public static void RunMigrations()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MemeLordDb"].ConnectionString;

            DeployChanges.To.SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build()
                    .PerformUpgrade();
        }
    }
}