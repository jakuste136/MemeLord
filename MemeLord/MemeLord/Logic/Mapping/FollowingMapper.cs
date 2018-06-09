using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public interface IFollowingMapper: IMapper<Following, FollowingDto>
    {

    }

    public class FollowingMapper : Mapper<Following, FollowingDto>, IFollowingMapper
    {

    }
}