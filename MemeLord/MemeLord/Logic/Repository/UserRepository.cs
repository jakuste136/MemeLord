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
                db.Execute(
                    $"INSERT INTO [dbo].[UserRoles]  ([UserId],[RoleId])  VALUES ({userRole.User.Id} , {userRole.Role.Id})");
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
                //return db.Query<User>()
                //    .Where(u => 
                //        u.Username.StartsWith(username) && u.Sex == GetGender(sex) && u.BannedDate.HasValue == IsBanned(status))
                //    .ToList();
                var paramUsername = 1;
                var paramSex = 1;
                var paramBanned = 1;
                var notStr = "";

                if (string.IsNullOrEmpty(username))
                    paramUsername = 0;

                if (sex.Equals("0"))
                    paramSex = 0;

                if (status == 0)
                    paramBanned = 0;

                if (status == 2)
                    notStr = "NOT";

                return db.Fetch<User>(
                    $"SELECT * FROM [Users] U WHERE ({paramUsername} = 0 OR U.Username LIKE '{username}%') AND ({paramSex} = 0 OR U.Sex LIKE '{GetGender(sex)}') AND ({paramBanned} = 0 OR ([U].[BannedDate] is {notStr} null))");
            }
        }

        private static bool IsBanned(int status)
        {
            return status != 1;
        }

        private static Sex GetGender(string sex)
        {
            if (string.IsNullOrEmpty(sex))
                return Sex.Undefined;
            return sex.Equals("2") ? Sex.Female : Sex.Male;
        }
    }
}