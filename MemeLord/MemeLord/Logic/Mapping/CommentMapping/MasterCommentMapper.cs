using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.CommentMapping
{
    public interface IMasterCommentMapper : IMapper<Comment, CommentDto>
    {
    }

    public class MasterCommentMapper : Mapper<Comment, CommentDto>, IMasterCommentMapper
    {
        private readonly IAnswerCommentMapper _answerCommentMapper;

        public MasterCommentMapper(IAnswerCommentMapper answerCommentMapper)
        {
            _answerCommentMapper = answerCommentMapper;
        }

        public override IMappingExpression<Comment, CommentDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dto => dto.Avatar, map => map.MapFrom(comment => comment.User.Avatar))
                .ForMember(dto => dto.Username, map => map.MapFrom(comment => comment.User.Username))
                .ForMember(dto => dto.Answers, map => map.ResolveUsing(comment => _answerCommentMapper.Map(comment.Answers)));
        }
    }
}