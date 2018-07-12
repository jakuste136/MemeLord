using System.Collections.Generic;

namespace MemeLord.DataObjects.Response.UserResponses
{
    public class GetUserReportResponse
    {
        public List<SingleUserReportResponse> Users { get; set; }
    }
}