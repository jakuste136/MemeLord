using MemeLord.Logic.Authentication;
using MemeLord.Logic.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public class UserMapper
    {
        public User Map(UserDto source)
        {
            return new User
            {
                Username = source.Username,
                Email = source.Email,
                Sex = source.Sex,
                DateOfBirth = source.DateOfBirth,
                Salt = HashManager.Hash(source.Password)
            };
        }
    }
}