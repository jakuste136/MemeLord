using System.Net;
using System.Net.Http;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Mapping.Users;
using MemeLord.Logic.Repository;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserAddModule
    {
        HttpResponseMessage AddUser(AddUserRequest userDto);
    }

    public class UserAddModule : IUserAddModule
    {
        private readonly IAddUserRequestMapper _requestMapper;
        private readonly IUserRepository _userRepository;
        private readonly HashManager _hashManager;

        public UserAddModule(IAddUserRequestMapper requestMapper, IUserRepository userRepository, HashManager hashManager)
        {
            _requestMapper = requestMapper;
            _userRepository = userRepository;
            _hashManager = hashManager;
        }

        public HttpResponseMessage AddUser(AddUserRequest request)
        {
            if (request == null) return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            var user = _requestMapper.Map(request);
            user.Hash = _hashManager.Hash(request.Password);

            _userRepository.SaveUser(user);
            
            var role = _userRepository.GetDefaultRole();
            _userRepository.SaveUserRole(new UserRole
            {
                User = user,
                Role = role
            });

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}