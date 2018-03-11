using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public class UserQueries
    {
        public IEnumerable<User> GetUsers()
        {
            using (var db = DatabaseFactory.GetConnection())
            {
                return db.Query<User>("");
            }
        }

        public User GetUserById(int id)
        {
            using (var db = DatabaseFactory.GetConnection())
            {
                return db.SingleOrDefault<User>(id);
            }
        }
    }
}