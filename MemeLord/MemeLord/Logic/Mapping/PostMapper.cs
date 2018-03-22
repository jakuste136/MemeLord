using System.Collections.Generic;
using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public interface IPostMapper : IMapper<Post, PostDto>
    {
    }

    public class PostMapper : Mapper<Post, PostDto>, IPostMapper
    {
        public override IMappingExpression<Post, PostDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dst => dst.Username, map => map.MapFrom(src => src.Op.Username));
        }
    }
}