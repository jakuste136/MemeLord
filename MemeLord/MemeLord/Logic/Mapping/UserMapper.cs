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
                Hash = HashManager.Hash(source.Password)
            };
        }

        public UserDto Map(User source)
        {
            return new UserDto
            {
                Username = source.Username,
                Email = source.Email,
                Sex = source.Sex,
                DateOfBirth = source.DateOfBirth
            };
        }
    }
}