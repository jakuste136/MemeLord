using System.Collections.Generic;

namespace MemeLord.Controllers
{
    public class GetReportTypesReponse
    {
        public IList<ReportTypeDto> ReportTypes { get; set; }
    }
}