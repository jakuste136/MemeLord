﻿using System.Linq;
using MemeLord.DataObjects.Response.ReportResponses;
using MemeLord.Logic.Mapping.Reports;
using MemeLord.Logic.Repository;
using MemeLord.Configuration;

namespace MemeLord.Logic.Modules.Reports
{
    public interface IGetReportsModule
    {
        GetReportedPostsResponse GetReportedPosts(int lastId, int count);
        GetReportedCommentsResponse GetReportedComments(int lastId, int count);
    }

    public class GetReportsModule : IGetReportsModule
    {
        private IReportRepository _reportRepository;
        private IReportedPostMapper _reportedPostMapper;
        private IReportedCommentMapper _reportedCommentMapper;
        private ReportingConfiguration _reportingConfiguration;

        public GetReportsModule(IReportRepository reportRepository, IReportedPostMapper reportedPostMapper, IReportedCommentMapper reportedCommentMapper, ReportingConfiguration reportingConfiguration)
        {
            _reportRepository = reportRepository;
            _reportedPostMapper = reportedPostMapper;
            _reportedCommentMapper = reportedCommentMapper;
            _reportingConfiguration = reportingConfiguration;
        }

        public GetReportedPostsResponse GetReportedPosts(int lastId, int count)
        {
            var repositoryReports = _reportRepository.GetReportedPosts(lastId);  //ogarnać liczbę postów do infinity scrolla

            FindMostFrequentReport findMostFrequentReport = new FindMostFrequentReport();
            var reportedPosts = findMostFrequentReport.ForPost(repositoryReports, _reportingConfiguration.MinimumReportsNumber, count);
            var reportedPostDtos = _reportedPostMapper.Map(reportedPosts);
            return new GetReportedPostsResponse
            {
                LastId = reportedPostDtos.Count() == 0 ? 0 : reportedPostDtos.Last().PostId,
                ReportedPosts = reportedPostDtos
            };
        }

        public GetReportedCommentsResponse GetReportedComments(int lastId, int count)
        {
            var repositoryReports = _reportRepository.GetReportedComments(lastId);

            FindMostFrequentReport findMostFrequentReport = new FindMostFrequentReport();
            var reportedComments = findMostFrequentReport.ForComment(repositoryReports, _reportingConfiguration.MinimumReportsNumber, count);
            var reportedCommentDtos = _reportedCommentMapper.Map(reportedComments);
            return new GetReportedCommentsResponse
            {
                LastId = reportedCommentDtos.Count() == 0 ? 0 : reportedCommentDtos.Last().CommentId,
                ReportedComments = reportedCommentDtos
            };
        }
    }
}