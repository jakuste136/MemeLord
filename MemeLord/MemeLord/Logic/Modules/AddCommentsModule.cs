using MemeLord.DataObjects.Request;
using MemeLord.Logic.Repository;
using MemeLord.Logic.Mapping.CommentMapping;
using MemeLord.Models;

namespace MemeLord.Logic.Modules
{
    public interface IAddCommentsModule
    {
        void AddComment(AddCommentRequest comment);
    }

    public class AddCommentsModule : IAddCommentsModule
    {
        private readonly ICommentRepository _commentRepository;
        private readonly INewCommentMapper _newCommentMapper;

        public AddCommentsModule(ICommentRepository commentRepository, INewCommentMapper newCommentMapper)
        {
            _commentRepository = commentRepository;
            _newCommentMapper = newCommentMapper;
        }

        public void AddComment(AddCommentRequest addCommentRequest)
        {
            var comment = _newCommentMapper.Map(addCommentRequest);
            _commentRepository.AddComment(comment);
        }
    }
}