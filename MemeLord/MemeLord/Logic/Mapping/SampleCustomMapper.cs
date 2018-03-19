using AutoMapper;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public class SampleCustomMapper : Mapper<User, Post>
    {
        public override IMappingExpression<User, Post> CreateMap(IMapperConfigurationExpression cfg)
        {
            // maps destination postDto.Title from source user.UserName

            return base.CreateMap(cfg)
                .ForMember(c => c.Title, map => map.MapFrom(src => src.Username));
        }
    }
}