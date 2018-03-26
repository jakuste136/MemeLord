using System.Net;
using System.Net.Http;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserAddModule
    {
        HttpResponseMessage AddUser(UserDto userDto);
    }

    public class UserAddModule : IUserAddModule
    {
        private readonly IUserDtoMapper _userMapper;
        private readonly IUserRepository _userRepository;
        private readonly HashManager _hashManager;

        public UserAddModule(IUserDtoMapper userMapper, IUserRepository userRepository, HashManager hashManager)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
            _hashManager = hashManager;
        }

        public HttpResponseMessage AddUser(UserDto userDto)
        {
            var user = _userMapper.Map(userDto);
            user.Hash = _hashManager.Hash(userDto.Password);
            _userRepository.SaveUser(user);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}