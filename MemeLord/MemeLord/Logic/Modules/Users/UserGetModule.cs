using System.Collections.Generic;
using System.Linq;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserGetModule
    {
        UserDto GetUserById(int id);
        IList<UserDto> GetAllUsers();
    }

    public class UserGetModule : IUserGetModule
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserGetModule(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return _userMapper.Map(user);
        }

        public IList<UserDto> GetAllUsers()
        {
            var userList = _userRepository.GetUsers();
            return _userMapper.Map(userList.ToList());
        }
    }
}