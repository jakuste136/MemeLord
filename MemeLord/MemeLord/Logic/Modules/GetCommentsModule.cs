using System.Linq;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping.CommentMapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules
{
    public interface IGetCommentsModule
    {
        GetPostCommentsResponse GetPostComments(int postId, int lastId, int count);
    }

    public class GetCommentsModule : IGetCommentsModule
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMasterCommentMapper _masterCommentMapper;

        public GetCommentsModule (ICommentRepository commentRepository, IMasterCommentMapper masterCommentMapper)
        {
            _commentRepository = commentRepository;
            _masterCommentMapper = masterCommentMapper;
        }

        public GetPostCommentsResponse GetPostComments(int postId, int lastId, int count)
        {
            var comments = _commentRepository.GetManyComments(postId, lastId, count);
            var commentDtos = _masterCommentMapper.Map(comments);

            return new GetPostCommentsResponse
            {
                LastId = commentDtos.Count == 0 ? 0 : commentDtos.Last().Id,
                CommentsList = commentDtos
            };
        }
    }
}