using MemeLord.Logic.Repository;
using MemeLord.Configuration;

namespace MemeLord.Logic.Modules.Reports
{
    public interface IAutoBanModule
    {
        void BanIfDeserveByCommentId(int commentId);
        void BanIfDeserveByPostId(int postId);
    }

    public class AutoBanModule : IAutoBanModule
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ReportingConfiguration _reportingConfiguration;

        public AutoBanModule(ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository, ReportingConfiguration reportingConfiguration)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _reportingConfiguration = reportingConfiguration;
        }

        public void BanIfDeserveByCommentId(int commentId)
        {
            int userId = _commentRepository.GetCommentById(commentId).User.Id;
            if (_commentRepository.GetNumberOfDeletedByUserId(userId) + _postRepository.GetNumberOfDeletedByUserId(userId) >= _reportingConfiguration.MinimumDeletionsNumber)
            {
                var user = _userRepository.GetUserById(userId);
                if (user.BannedDate != null)
                    return;

                user.BannedDate = System.DateTime.Now;
                _userRepository.SaveUser(user);
            }
        }

        public void BanIfDeserveByPostId(int postId)
        {
            var userId = _postRepository.GetPostById(postId).Op.Id;

            if (_commentRepository.GetNumberOfDeletedByUserId(userId) +
                _postRepository.GetNumberOfDeletedByUserId(userId) <
                _reportingConfiguration.MinimumDeletionsNumber)
                return;

            var user = _userRepository.GetUserById(userId);
            if (user.BannedDate != null)
                return;

            user.BannedDate = System.DateTime.Now.AddMonths(1);

            _userRepository.SaveUser(user);
        }
    }
}