using System.Net;
using System.Net.Http;
using MemeLord.DataObjects.Dto;
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

        public UserAddModule(IUserDtoMapper userMapper, IUserRepository userRepository)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
        }

        public HttpResponseMessage AddUser(UserDto userDto)
        {
            var user = _userMapper.Map(userDto);
            _userRepository.SaveUser(user);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}