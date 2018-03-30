using System.Collections.Generic;
using MemeLord.DataObjects.Response;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Users
{
    public interface IGetUserResponseMapper
    {
        GetUserResponse Map(User source);
        IList<GetUserResponse> Map(IList<User> sourceItemsList);
    }

    public class GetUserResponseMapper : Mapper<User, GetUserResponse>, IGetUserResponseMapper
    {
    }
}