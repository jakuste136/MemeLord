using MemeLord.Logic.Repository;
using MemeLord.DataObjects.Response.ReportResponses;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Request.Reports;
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

        [Route("get/{id}")]
        public Report GetReportById(int id)
        {
            return _reportRepository.GetReportById(id);
        }

        [Route("get-posts")]
        [HttpGet]
        public GetReportedPostsResponse GetReportedPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedPosts(lastId, count);
        }

        [Route("get-posts")]
        [HttpGet]
        public GetReportedCommentsResponse GetReportedComments([FromUri] int lastId, [FromUri] int count)
        {
            return _getReportsModule.GetReportedComments(lastId, count);
        }

        [Route("add-report")]
        [HttpPost]
        public void AddReport(AddReportRequest request)
        {
            _addReportModule.AddReport(request);
        }
    }
}