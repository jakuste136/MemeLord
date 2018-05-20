using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Request.Reports;
using MemeLord.DataObjects.Response.Reports;
using MemeLord.Logic.Modules.Reports;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        private readonly IReportRepository _reportRepository;
        private readonly IGetReportsModule _getReportsModule;
        private readonly IAddReportModule _addReportModule;

        public ReportController(IReportRepository reportRepository, IGetReportsModule getReportsModule, IAddReportModule addReportModule)
        {
            _reportRepository = reportRepository;
            _getReportsModule = getReportsModule;
            _addReportModule = addReportModule;
        }

        [Route("posts")]
        [HttpGet]
        public GetReportedPostsResponse GetReportedPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedPosts(lastId, count);
        }

        [Route("check-post")]
        [HttpGet]
        public bool CheckIfPostAlreadyReported([FromUri] int userId, [FromUri] int postId)
        {
            return _reportRepository.DidUserReportPost(userId, postId);
        }

        [Route("comments")]
        [HttpGet]
        public GetReportedCommentsResponse GetReportedComments([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedComments(lastId, count);
        }

        [Route("check-comment")]
        [HttpGet]
        public bool CheckIfCommentAlreadyReported([FromUri] int userId, [FromUri] int commentId)
        {
            return _reportRepository.DidUserReportComment(userId, commentId);
        }
        
        [HttpPost]
        public void AddReport(AddReportRequest request)
        {
            _addReportModule.AddReport(request);
        }
    }
}