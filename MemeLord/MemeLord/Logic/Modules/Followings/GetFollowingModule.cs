using System.Collections.Generic;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;
using System.Linq;
using System.Security.Claims;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping.Users;

namespace MemeLord.Logic.Modules.Followings
{
    public interface IGetFollowingModule
    {
        FollowingDto GetFollowing(string authorName);
        List<GetUserResponse> GetFollowers();
    }

    public class GetFollowingModule : IGetFollowingModule
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly IFollowingMapper _followingMapper;
        private readonly IGetUserResponseMapper _getUserResponseMapper;

        public GetFollowingModule(IFollowingRepository followingRepository,
            IFollowingMapper followingMapper, IGetUserResponseMapper getUserResponseMapper)
        {
            _followingRepository = followingRepository;
            _followingMapper = followingMapper;
            _getUserResponseMapper = getUserResponseMapper;
        }

        public FollowingDto GetFollowing(string authorName)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            var following = _followingRepository.GetFollowing(authorName, int.Parse(userId));
            return _followingMapper.Map(following);
        }

        public List<GetUserResponse> GetFollowers()
        {
            var username = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "0";
            var users = _followingRepository.StepaniakToKutas(username);
            return users.Select(u => _getUserResponseMapper.Map(u)).ToList();
        }
    }
}