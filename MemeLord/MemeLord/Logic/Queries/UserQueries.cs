﻿using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface IUserQueries
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }

    public class UserQueries : IUserQueries
    {
        public IEnumerable<User> GetUsers()
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>().ToEnumerable();
            }
        }

        public User GetUserById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>()
                    .SingleOrDefault(u => u.Id == id);
            }
        }
    }
}