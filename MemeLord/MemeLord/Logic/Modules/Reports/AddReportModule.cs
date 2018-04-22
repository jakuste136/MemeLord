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
        private IReportRepository _reportRepository;
        private INewReportMapper _newReportMapper;

        public AddReportModule(IReportRepository reportRepository, INewReportMapper newReportMapper)
        {
            _reportRepository = reportRepository;
            _newReportMapper = newReportMapper;
        }

        public void AddReport(AddReportRequest request)
        {
            var report = _newReportMapper.Map(request);
            _reportRepository.AddReport(report);
        }
    }
}