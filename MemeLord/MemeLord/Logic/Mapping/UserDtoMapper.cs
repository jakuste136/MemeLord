using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Authentication;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public interface IUserDtoMapper
    {
        User Map(UserDto source);
    }

    public class UserDtoMapper : Mapper<UserDto, User>, IUserDtoMapper
    {
        public override IMappingExpression<UserDto, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(usr => usr.Hash, map => map.ResolveUsing(GetHash));
        }

        public string GetHash(UserDto dto)
        {
            return HashManager.Hash(dto.Password);
        }
    }
}