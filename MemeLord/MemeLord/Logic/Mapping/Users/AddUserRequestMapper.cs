using AutoMapper;
using MemeLord.DataObjects.Request;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Users
{
    public interface IAddUserRequestMapper
    {
        User Map(AddUserRequest source);
    }

    public class AddUserRequestMapper : Mapper<AddUserRequest, User>, IAddUserRequestMapper
    {
        public override IMappingExpression<AddUserRequest, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(usr => usr.Hash, map => map.Ignore());
        }
    }
}