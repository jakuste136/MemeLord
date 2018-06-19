using MemeLord.DataObjects.Request;
using System.Net.Http;
using System;
using MemeLord.Logic.Repository;
using System.Security.Claims;
using System.Net;
using System.Linq;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Followings
{
    public interface IUpsertFollowingModule
    {
        HttpResponseMessage UpsertFollowing(FollowRequest request);
    }

    public class UpsertFollowingModule : IUpsertFollowingModule
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly IUserRepository _userRepository;

        public UpsertFollowingModule(IFollowingRepository followingRepository,
            IUserRepository userRepository)
        {
            _followingRepository = followingRepository;
            _userRepository = userRepository;
        }

        public HttpResponseMessage UpsertFollowing(FollowRequest request)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            var following = new Following
            {
                Follower = _userRepository.GetUserByCredentials(request.AuthorName),
                Followed = _userRepository.GetUserById(int.Parse(userId)),
                Active = request.Follow
            };

            _followingRepository.UpsertFollowing(following);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}