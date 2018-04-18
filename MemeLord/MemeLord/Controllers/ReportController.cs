using MemeLord.Logic.Repository;
using MemeLord.DataObjects.Response.ReportResponses;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules.Reports;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiController
    {
        private readonly IReportRepository _reportRepository;
        private readonly IGetReportsModule _getReportsModule;

        [Route("get/{id}")]
        public Report GetReportById(int id)
        {
            return _reportRepository.GetReportById(id);
        }

        [Route("get-posts")]
        [HttpGet]
        public GetReportedPostsResponse GetReportedPosts(int lastId, int count)
        {
            return _getReportsModule.GetReportedPosts(lastId, count);
        }
    }
}