using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.CommentMapping
{
    public interface IAnswerCommentMapper : IMapper<Comment, CommentDto>
    {
    }

    public class AnswerCommentMapper : Mapper<Comment, CommentDto>, IAnswerCommentMapper
    {
        public override IMappingExpression<Comment, CommentDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dto => dto.Username, map => map.MapFrom(comment => comment.User.Username))
                .ForMember(dto => dto.Answers, map => map.Ignore());
        }
    }
}