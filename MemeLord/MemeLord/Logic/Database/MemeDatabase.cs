using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace MemeLord.Logic.Database
{
    public class MemeDatabase : NPoco.Database
    {
        public MemeDatabase(string connectionString) : base(connectionString)
        {
        }

        protected override void OnExecutingCommand(DbCommand dbCommand)
        {
            Debug.WriteLine(dbCommand.CommandText);
        }
    }
}