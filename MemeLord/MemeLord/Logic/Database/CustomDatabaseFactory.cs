using NPoco;
using NPoco.FluentMappings;

namespace MemeLord.Logic.Database
{
    public static class CustomDatabaseFactory
    {
        public static DatabaseFactory DatabaseFactory { get; set; }

        public static void Setup()
        {
            var config = FluentMappingConfiguration.Configure(new CustomMappings());

            DatabaseFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new MemeDatabase("MemeLordDb"));
                x.WithFluentConfig(config);
            });
        }

        public static MemeDatabase GetConnection()
        {
            return (MemeDatabase) DatabaseFactory.GetDatabase();
        }
    }
}