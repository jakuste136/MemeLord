using AutoMapper;
using MemeLord.Logic.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public class PostMapper : Mapper<Post, PostDto>
    {
        public override IMappingExpression<Post, PostDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dst => dst.Username, map => map.MapFrom(src => src.Op.Username));
        }
    }
}