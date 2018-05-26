using MemeLord.Logic.Extensions;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Reports
{
    public interface ICheckIfUserHasReported
    {
        bool Comment(int commentId);
        bool Post(int postId);
    }

    public class CheckIfUserHasReported : ICheckIfUserHasReported
    {
        private readonly IReportRepository _reportRepository;

        public CheckIfUserHasReported(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        public bool Comment(int commentId)
        {
            var userId = ClaimsPrincipalWrapper.GetIdFromClaim();

            return _reportRepository.DidUserReportComment(userId, commentId);
        }

        public bool Post(int postId)
        {
            var userId = ClaimsPrincipalWrapper.GetIdFromClaim();

            return _reportRepository.DidUserReportPost(userId, postId);
        }
    }
}