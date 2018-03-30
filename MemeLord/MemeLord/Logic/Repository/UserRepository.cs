﻿using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface IUserRepository
    {
        IList<User> GetUsers();
        User GetUserById(int id);
        User GetUserByCredentials(string username);
        void SaveUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        public IList<User> GetUsers()
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>().ToList();
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

        public User GetUserByCredentials(string username)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>()
                    .SingleOrDefault(u => u.Username == username);
            }
        }

        public void SaveUser(User user)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(user);
            }
        }
    }
}