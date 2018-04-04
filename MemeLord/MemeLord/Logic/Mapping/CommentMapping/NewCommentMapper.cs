using AutoMapper;
using MemeLord.Models;
using MemeLord.DataObjects.Request;

namespace MemeLord.Logic.Mapping.CommentMapping
{
    public interface INewCommentMapper : IMapper<AddCommentRequest, Comment>
    {
    }


    public class NewCommentMapper : Mapper<AddCommentRequest, Comment>, INewCommentMapper
    {
        public override IMappingExpression<AddCommentRequest, Comment> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForPath(comment => comment.MasterComment.Id, map => map.MapFrom(request => request.MasterCommentId))
                .ForPath(comment => comment.Post.Id, map => map.MapFrom(request => request.PostId))
                .ForPath(comment => comment.User.Id, map => map.MapFrom(request => request.UserId))
                .ForMember(comment => comment.Answers, map => map.Ignore())
                .ForMember(comment => comment.DeletionDate, map => map.Ignore());
        }
    }
}