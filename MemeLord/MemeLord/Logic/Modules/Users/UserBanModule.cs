using System;
using System.Net;
using System.Net.Http;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserBanModule
    {
        HttpResponseMessage BanUser(BanUserRequest request);
    }

    public class UserBanModule : IUserBanModule
    {
        private readonly IUserRepository _userRepository;

        public UserBanModule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public HttpResponseMessage BanUser(BanUserRequest request)
        {
            var user = _userRepository.GetUserByCredentials(request.Username);

            if (user == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            user.BannedDate = DateTime.Now.AddMonths(1);
            _userRepository.SaveUser(user);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}