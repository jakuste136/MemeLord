using System.Linq;
using System.Collections.Generic;
using MemeLord.Models;

namespace MemeLord.Logic.Modules.Reports
{
    public class FindMostFrequentReport
    {
        public List<Report> ForPost(List<Report> reports, int minimumCount, int maxCount)
        {
            var reportedPosts = new List<Report>();
            foreach (var report in reports)
            {
                if (reports.FindAll(r => r.Post.Id == report.Post.Id).Count() >= minimumCount && !reportedPosts.Any(r => r.Post.Id == report.Post.Id) && reportedPosts.Count() <= maxCount)
                {
                    var actualPostReports = new List<Report>();
                    actualPostReports.AddRange(reports.FindAll(r => r.Post.Id == report.Post.Id));

                    IEnumerable<IGrouping<string, int>> reportTypeGroups =
                        actualPostReports
                        .GroupBy(r => r.ReportType.Description, r => actualPostReports.FindAll(rep => rep.ReportType.Id == r.ReportType.Id).Count())
                        .OrderByDescending(r => r.First());
                    reportedPosts.Add(actualPostReports.Find(r => r.ReportType.Description == reportTypeGroups.First().Key));
                }
            }
            return reportedPosts;
        }

        public List<Report> ForComment(List<Report> reports, int minimumCount, int maxCount)
        {
            var reportedComments = new List<Report>();
            foreach (var report in reports)
            {
                if (reports.FindAll(r => r.Comment.Id == report.Comment.Id).Count() >= minimumCount && !reportedComments.Any(r => r.Comment.Id == report.Comment.Id) && reportedComments.Count() <= maxCount)
                {
                    var actualCommentReports = new List<Report>();
                    actualCommentReports.AddRange(reports.FindAll(r => r.Comment.Id == report.Comment.Id));

                    IEnumerable<IGrouping<string, int>> reportTypeGroups =
                        actualCommentReports
                        .GroupBy(r => r.ReportType.Description, r => actualCommentReports.FindAll(rep => rep.ReportType.Id == r.ReportType.Id).Count())
                        .OrderByDescending(r => r.First());
                    reportedComments.Add(actualCommentReports.Find(r => r.ReportType.Description == reportTypeGroups.First().Key));
                }
            }
            return reportedComments;
        }
    }
}