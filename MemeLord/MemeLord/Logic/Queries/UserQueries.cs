using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface IUserQueries
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByCredentials(string username);
        void SaveUser(UserDto userObject);
    }

    public class UserQueries : IUserQueries
    {
        private readonly IMapper<UserDto, User> _userMapper;

        public UserQueries(IMapper<UserDto, User> userMapper)
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

        public void SaveUser(UserDto userObject)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var user = _userMapper.Map(userObject);
                db.Save(user);
            }
        }
    }
}