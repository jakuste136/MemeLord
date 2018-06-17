using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
        List<User> GetUsersForReport(string username, string sex, int status);
        void SaveUserRole(UserRole userRole);
        Role GetUserRoleByUserId(int userId);
        Role GetDefaultRole();
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

        public void SaveUserRole(UserRole userRole)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(userRole);
            }
        }

        public Role GetUserRoleByUserId(int userId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<UserRole>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .Where(ur => ur.User.Id == userId)
                    .FirstOrDefault()?
                    .Role;
            }
        }

        public Role GetDefaultRole()
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Role>().SingleOrDefault(r => r.Name == "Member");
            }
        }

        public List<User> GetUsersForReport(string username, string sex, int status)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<User>()
                    .Where(u => 
                        u.Username.StartsWith(username) && u.Sex == GetGender(sex) && u.BannedDate.HasValue == IsBanned(status))
                    .ToList();
            }
        }

        private bool IsBanned(int status)
        {
            if (status == 1)
                return false;
            else
                return true;
        }

        private Sex GetGender(string sex)
        {
            if (string.IsNullOrEmpty(sex))
                return Sex.Undefined;
            if (sex.Equals("Female"))
                return Sex.Female;
            else
                return Sex.Male;
        }
    }
}