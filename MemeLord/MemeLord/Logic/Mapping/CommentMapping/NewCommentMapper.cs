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
                .ForMember(comment => comment.MasterComment, map => map.ResolveUsing(request => request.MasterCommentId))
                .ForMember(comment => comment.Post, map => map.ResolveUsing(request => request.PostId))
                .ForMember(comment => comment.User, map => map.ResolveUsing(request => request.UserId))
                .ForMember(comment => comment.Answers, map => map.Ignore())
                .ForMember(comment => comment.DeletionDate, map => map.Ignore());
        }
    }
}