using AutoMapper;
using MemeLord.Logic.Authentication;
using MemeLord.Logic.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public class SampleCustomMapper : Mapper<UserDto, User>
    {
        // TODO: [Mateusz] testIt!
        public override IMappingExpression<UserDto, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            // maps destination postDto.Title from source user.UserName

            return base.CreateMap(cfg)
                .ForMember(usr => usr.Hash, map => map.ResolveUsing(GetHash));
        }

        public string GetHash(UserDto dto)
        {
            return HashManager.Hash(dto.Password);
        }
    }
}