using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using JsonPatch;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Mapping.Users;
using MemeLord.Logic.Repository;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserUpdateModule
    {
        HttpResponseMessage UpdateUser(UpdateUserRequest request);
        HttpResponseMessage UpdateUser(int id, JsonPatchDocument<User> userPatch);
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
            if (request == null) return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            var username = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "";
            var originalUser = _userRepository.GetUserByCredentials(username);
            if (originalUser == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            var newUser = _requestMapper.Map(request);
            newUser.Id = originalUser.Id;
            newUser.Username = username;
            newUser.Hash = originalUser.Hash;
            _userRepository.SaveUser(newUser);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage UpdateUser(int id, JsonPatchDocument<User> userPatch)
        {
            var userToUpdate = _userRepository.GetUserById(id);
            if (userToUpdate == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            foreach (var passwordChange in userPatch.Operations.Where(o => o.Path == $"/{nameof(userToUpdate.Hash)}"))
            {
                passwordChange.Value = _hashManager.Hash(passwordChange.Value.ToString());
            }

            userPatch.ApplyUpdatesTo(userToUpdate);
            _userRepository.SaveUser(userToUpdate);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}