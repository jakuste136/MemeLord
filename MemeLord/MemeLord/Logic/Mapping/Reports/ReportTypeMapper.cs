using MemeLord.Controllers;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Reports
{
    public interface IReportTypeMapper : IMapper<ReportType, ReportTypeDto>
    {
    }

    public class ReportTypeMapper : Mapper<ReportType, ReportTypeDto>, IReportTypeMapper
    {
    }
}