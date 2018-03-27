using System.Linq;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping.CommentMapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules
{
    public interface IGetCommentsModule
    {
        GetCommentsResponse GetPostComments(int postId, int lastId, int count);
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

        public GetCommentsResponse GetPostComments(int postId, int lastId, int count)
        {
            var comments = _commentRepository.GetManyComments(postId, lastId, count);
            var commentDtos = _masterCommentMapper.Map(comments);

            return new GetCommentsResponse
            {
                LastId = commentDtos.Count == 0 ? 0 : commentDtos.Last().Id,
                CommentsList = commentDtos
            };
        }

        public GetCommentsResponse GetBestComments(int postId, int count)
        {
            var comments = _commentRepository.GetBestComments(postId, count);
            var commentDtos = _masterCommentMapper.Map(comments);

            return new GetCommentsResponse
            {
                LastId = commentDtos.Count == 0 ? 0 : commentDtos.Last().Id,
                CommentsList = commentDtos
            };
        }
    }
}