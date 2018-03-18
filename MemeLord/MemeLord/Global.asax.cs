using System.Web.Http;
using MemeLord.Logic.Database;

namespace MemeLord
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CustomDatabaseFactory.Setup();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MigrationRunner.RunMigrations();
            AutofacConfig.Configure();
        }
    }
}
