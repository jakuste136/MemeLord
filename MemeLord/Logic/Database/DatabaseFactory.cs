namespace MemeLord.Logic.Database
{
    public static class DatabaseFactory
    {
        public static PetaPoco.Database GetConnection()
        {
            return new PetaPoco.Database("MemeLordDb");
        }
    }
}