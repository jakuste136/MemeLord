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
        private readonly HashManager _hashManager;

        public UserDtoMapper(HashManager hashManager)
        {
            _hashManager = hashManager;
        }

        public override IMappingExpression<UserDto, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(usr => usr.Hash, map => map.ResolveUsing(GetHash));
        }

        public string GetHash(UserDto dto)
        {
            return _hashManager.Hash(dto.Password);
        }
    }
}