using System.Net;
using System.Net.Http;
using System.Security.Claims;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Extensions;
using MemeLord.Logic.Mapping.Users;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserUpdateModule
    {
        HttpResponseMessage UpdateUser(UpdateUserRequest request);
    }

    public class UserUpdateModule : IUserUpdateModule
    {
        private readonly IUserRepository _userRepository;
        private readonly IUpdateUserRequestMapper _requestMapper;
        private readonly HashManager _hashManager;

        public UserUpdateModule(IUserRepository userRepository, IUpdateUserRequestMapper requestMapper, HashManager hashManager)
        {
            _userRepository = userRepository;
            _requestMapper = requestMapper;
            _hashManager = hashManager;
        }

        public HttpResponseMessage UpdateUser(UpdateUserRequest request)
        {
            if (request == null)
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            var username = ClaimsPrincipalWrapper.GetFromClaim(ClaimTypes.Name);
            var originalUser = _userRepository.GetUserByCredentials(username);
            if (originalUser == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            _requestMapper.Map(request, originalUser);
            _userRepository.SaveUser(originalUser);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}