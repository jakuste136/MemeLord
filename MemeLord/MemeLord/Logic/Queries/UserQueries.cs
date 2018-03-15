using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface IUserQueries
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
    }

    public class UserQueries : IUserQueries
    {
        public IEnumerable<Users> GetUsers()
        {
            using (var db = DatabaseFactory.GetConnection())
            {
                return db.Query<Users>("");
            }
        }

        public Users GetUserById(int id)
        {
            using (var db = DatabaseFactory.GetConnection())
            {
                return db.SingleOrDefault<Users>(id);
            }
        }
    }
}