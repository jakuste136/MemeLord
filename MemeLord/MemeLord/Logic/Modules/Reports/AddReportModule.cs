using System;
using System.Net.Http;
using MemeLord.DataObjects.Request.Reports;
using MemeLord.Logic.Repository;
using MemeLord.Logic.Mapping.Reports;

namespace MemeLord.Logic.Modules.Reports
{
    public interface IAddReportModule
    {
        void AddReport(AddReportRequest request);
    }

    public class AddReportModule : IAddReportModule
    {
        private readonly IReportRepository _reportRepository;
        private readonly INewReportMapper _newReportMapper;

        public AddReportModule(IReportRepository reportRepository, INewReportMapper newReportMapper)
        {
            _reportRepository = reportRepository;
            _newReportMapper = newReportMapper;
        }

        public void AddReport(AddReportRequest request)
        {
            if (request.PostId.HasValue && request.CommentId.HasValue)
                throw new ArgumentException("Cannot report comment and post at the same time");

            var report = _newReportMapper.Map(request);

            _reportRepository.AddReport(report);
        }
    }
}