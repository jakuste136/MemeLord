using System.Linq;
using System.Net;
using System.Net.Http;
using JsonPatch;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Repository;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserUpdateModule
    {
        HttpResponseMessage UpdateUser(int id, JsonPatchDocument<User> userPatch);
    }

    public class UserUpdateModule : IUserUpdateModule
    {
        private readonly IUserRepository _userRepository;
        private readonly HashManager _hashManager;

        public UserUpdateModule(IUserRepository userRepository, HashManager hashManager)
        {
            _userRepository = userRepository;
            _hashManager = hashManager;
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