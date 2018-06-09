using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;
using System.Linq;
using System.Security.Claims;

namespace MemeLord.Logic.Modules.Followings
{
    public interface IGetFollowingModule
    {
        FollowingDto GetFollowing(string authorName);
    }

    public class GetFollowingModule : IGetFollowingModule
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly IFollowingMapper _followingMapper;

        public GetFollowingModule(IFollowingRepository followingRepository,
            IFollowingMapper followingMapper)
        {
            _followingRepository = followingRepository;
            _followingMapper = followingMapper;
        }

        public FollowingDto GetFollowing(string authorName)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            var following = _followingRepository.GetFollowing(authorName, int.Parse(userId));
            return _followingMapper.Map(following);
        }
    }
}