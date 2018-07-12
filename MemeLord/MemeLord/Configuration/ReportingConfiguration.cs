using MemeLord.Configuration.Settings;

namespace MemeLord.Configuration
{
    public class ReportingConfiguration
    {
        public int MinimumReportsNumber => ReportingSettings.Default.MinimumReportsNumber;
        public int MinimumDeletionsNumber => ReportingSettings.Default.MinimumDeletionsNumber;
    }
}