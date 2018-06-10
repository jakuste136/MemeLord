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
        private readonly IGetReportsModule _getReportsModule;
        private readonly IAddReportModule _addReportModule;
        private readonly ICheckIfUserHasReported _checkIfUserHasReported;

        public ReportController(IGetReportsModule getReportsModule, IAddReportModule addReportModule, ICheckIfUserHasReported checkIfUserHasReported)
        {
            _getReportsModule = getReportsModule;
            _addReportModule = addReportModule;
            _checkIfUserHasReported = checkIfUserHasReported;
        }

        [Route("posts")]
        [HttpGet, Authorize(Roles = "Admin")]
        public GetReportedPostsResponse GetReportedPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedPosts(lastId, count);
        }

        [Route("check-post")]
        [HttpGet, Authorize(Roles = "Admin")]
        public bool CheckIfPostAlreadyReported([FromUri] int postId)
        {
            return _checkIfUserHasReported.Post(postId);
        }

        [Route("comments")]
        [HttpGet, Authorize(Roles = "Admin")]
        public GetReportedCommentsResponse GetReportedComments([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedComments(lastId, count);
        }

        [Route("check-comment")]
        [HttpGet]
        public bool CheckIfCommentAlreadyReported([FromUri] int commentId)
        {
            return _checkIfUserHasReported.Comment(commentId);
        }

        [Route("types")]
        [HttpGet]
        public GetReportTypesReponse GetReportTypes()
        {
            return _getReportsModule.GetReportTypes();
        }

        [HttpPost, Authorize(Roles = "Member, Admin")]
        public void AddReport(AddReportRequest request)
        {
            _addReportModule.AddReport(request);
        }
    }
}