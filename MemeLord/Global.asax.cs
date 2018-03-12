using System.Web.Http;

namespace MemeLord
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MigrationRunner.RunMigrations();
        }
    }
}
