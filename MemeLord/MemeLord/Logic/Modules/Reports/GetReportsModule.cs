using System.Linq;
using System.Collections.Generic;
using MemeLord.DataObjects.Response.ReportResponses;
using MemeLord.Logic.Mapping.Reports;
using MemeLord.Logic.Repository;
using MemeLord.Configuration;

namespace MemeLord.Logic.Modules.Reports
{
    public interface IGetReportsModule
    {
        GetReportedPostsResponse GetReportedPosts(int lastId, int count);
    }

    public class GetReportsModule : IGetReportsModule
    {
        private ReportRepository _reportRepository;
        private ReportedPostMapper _reportedPostDtoMapper;
        private ReportingConfiguration _reportingConfiguration;

        public GetReportsModule(ReportRepository reportRepository, ReportedPostMapper reportedPostDtoMapper, ReportingConfiguration reportingConfiguration)
        {
            _reportRepository = reportRepository;
            _reportedPostDtoMapper = reportedPostDtoMapper;
            _reportingConfiguration = reportingConfiguration;
        }

        public GetReportedPostsResponse GetReportedPosts(int lastId, int count)
        {
            var repositoryReports = _reportRepository.GetReportedPosts(lastId);  //ogarnać liczbę postów do infinity scrolla

            FindMostFrequentReport findMostFrequentReport = new FindMostFrequentReport();
            var reportedPosts = findMostFrequentReport.ForPost(repositoryReports, _reportingConfiguration.MinimumReportsNumber, count);
            var reportedPostDtos = _reportedPostDtoMapper.Map(reportedPosts);
            return new GetReportedPostsResponse
            {
                LastId = reportedPostDtos.Count() == 0 ? 0 : reportedPostDtos.Last().PostId,
                ReportedPosts = reportedPostDtos
            };
        }
    }
}