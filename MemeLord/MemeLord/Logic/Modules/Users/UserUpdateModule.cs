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
            if (request == null)
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            var username = GetFromClaim(ClaimTypes.Name);
            var originalUser = _userRepository.GetUserByCredentials(username);
            if (originalUser == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            // todo: [astek] assert do tego testu co napisalem 
            _requestMapper.Map(request, originalUser);
            
            _userRepository.SaveUser(originalUser);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public string GetFromClaim(string types)
        {
            // todo: [astek] przenies do jakiegos extension method albo cos 
            return ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == types)?.Value ?? "";
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