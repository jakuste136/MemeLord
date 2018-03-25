using System.Collections.Generic;
using System.Linq;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;
using MemeLord.Models;


namespace MemeLord.Logic.Modules
{
    public interface IGetCommentsModule
    {
        GetPostCommentsResponse GetPostComments(int postId, int lastId, int count);
    }

    public class GetCommentsModule : IGetCommentsModule
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentMapper _commentMapper;

        public GetCommentsModule (ICommentRepository commentRepository, ICommentMapper commentMapper)
        {
            _commentRepository = commentRepository;
            _commentMapper = commentMapper;
        }


        public GetPostCommentsResponse GetPostComments(int postId, int lastId, int count)
        {
            var comments = _commentRepository.GetManyComments(postId, lastId, count);
            var commentDtos = _commentMapper.Map(comments);

            return new GetPostCommentsResponse
            {
                LastId = commentDtos.Count == 0 ? 0 : commentDtos.ElementAt(commentDtos.Count - 1).Id,
                CommentsList = commentDtos
            };
        }

    }
}