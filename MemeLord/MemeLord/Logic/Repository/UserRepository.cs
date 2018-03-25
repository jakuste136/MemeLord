using System;
using System.Collections.Generic;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Database;
using MemeLord.Logic.Mapping;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByCredentials(string username);
        [Obsolete]
        void SaveUser(UserDto userObject);
        void SaveUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IUserMapper _userMapper;

        public UserRepository(IUserMapper userMapper)
        {
            _userMapper = userMapper;
        }

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

        public User GetUserByCredentials(string username)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>()
                    .SingleOrDefault(u => u.Username == username);
            }
        }

        [Obsolete]
        public void SaveUser(UserDto userObject)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var user = _userMapper.Map(userObject);
                db.Save(user);
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