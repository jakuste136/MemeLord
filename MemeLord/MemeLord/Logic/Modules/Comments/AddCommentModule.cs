using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Mapping.CommentMapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules
{
    public interface IAddCommentsModule
    {
        CommentDto AddComment(AddCommentRequest comment);
    }

    public class AddCommentsModule : IAddCommentsModule
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMasterCommentMapper _masterCommentMapper;
        private readonly INewCommentMapper _newCommentMapper;
        private readonly IUserRepository _userRepository;

        public AddCommentsModule(ICommentRepository commentRepository, INewCommentMapper newCommentMapper,
            IMasterCommentMapper masterCommentMapper, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _newCommentMapper = newCommentMapper;
            _masterCommentMapper = masterCommentMapper;
            _userRepository = userRepository;
        }

        public CommentDto AddComment(AddCommentRequest addCommentRequest)
        {
            var comment = _newCommentMapper.Map(addCommentRequest);

            _commentRepository.AddComment(comment);

            var user = _userRepository.GetUserById(comment.User.Id);
            comment.User = user;

            return _masterCommentMapper.Map(comment);
        }
    }
}