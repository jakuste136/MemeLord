using System.Linq;
using MemeLord.Logic.Mapping.Reports;
using MemeLord.Logic.Repository;
using MemeLord.Configuration;
using MemeLord.Controllers;
using MemeLord.DataObjects.Response.Reports;
using MemeLord.Logic.Mapping;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Reports
{
    public interface IGetReportsModule
    {
        GetReportedPostsResponse GetReportedPosts(int lastId, int count);
        GetReportedCommentsResponse GetReportedComments(int lastId, int count);
        GetReportTypesReponse GetReportTypes();
    }

    public class GetReportsModule : IGetReportsModule
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportedPostMapper _reportedPostMapper;
        private readonly IReportedCommentMapper _reportedCommentMapper;

        private readonly ReportingConfiguration _reportingConfiguration;
        private readonly IReportTypeMapper _reportTypeMapper;

        public GetReportsModule(IReportRepository reportRepository, IReportedPostMapper reportedPostMapper,
            IReportedCommentMapper reportedCommentMapper, ReportingConfiguration reportingConfiguration,
            IReportTypeMapper reportTypeMapper)
        {
            _reportRepository = reportRepository;
            _reportedPostMapper = reportedPostMapper;
            _reportedCommentMapper = reportedCommentMapper;
            _reportingConfiguration = reportingConfiguration;
            _reportTypeMapper = reportTypeMapper;
        }

        public GetReportedPostsResponse GetReportedPosts(int lastId, int count)
        {
            var repositoryReports =
                _reportRepository.GetReportedPosts(lastId); //ogarnać liczbę postów do infinity scrolla

            var findMostFrequentReport = new FindMostFrequentReport();
            var reportedPosts = findMostFrequentReport.ForPost(repositoryReports,
                _reportingConfiguration.MinimumReportsNumber, count);
            var reportedPostDtos = _reportedPostMapper.Map(reportedPosts);
            return new GetReportedPostsResponse
            {
                LastId = !reportedPostDtos.Any() ? 0 : reportedPostDtos.Last().PostId,
                ReportedPosts = reportedPostDtos
            };
        }

        public GetReportedCommentsResponse GetReportedComments(int lastId, int count)
        {
            var repositoryReports = _reportRepository.GetReportedComments(lastId);

            var findMostFrequentReport = new FindMostFrequentReport();
            var reportedComments = findMostFrequentReport.ForComment(repositoryReports,
                _reportingConfiguration.MinimumReportsNumber, count);
            var reportedCommentDtos = _reportedCommentMapper.Map(reportedComments);
            return new GetReportedCommentsResponse
            {
                LastId = !reportedCommentDtos.Any() ? 0 : reportedCommentDtos.Last().CommentId,
                ReportedComments = reportedCommentDtos
            };
        }

        public GetReportTypesReponse GetReportTypes()
        {
            var reportTypes = _reportRepository.GetReportTypes();
            return new GetReportTypesReponse
            {
                ReportTypes = _reportTypeMapper.Map(reportTypes)
            };
        }
    }
}