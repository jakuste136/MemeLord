using MemeLord.Logic.Database;
using MemeLord.Models;
using System.Collections.Generic;

namespace MemeLord.Logic.Repository
{
    public interface IReportRepository
    {
        Report GetReportById(int id);
        List<Report> GetReportedPosts(int lastId);
        List<Report> GetReportedComments(int lastId);
        void AddReport(Report report);
    }

    public class ReportRepository : IReportRepository
    {
        public Report GetReportById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Report>()
                    .Include(r => r.Comment)
                    .Include(r => r.Post)
                    .Include(r => r.Reporter)
                    .Include(r => r.ReportType)
                    .SingleOrDefault(r => r.Id == id);
            }
        }

        public List<Report> GetReportedPosts(int lastId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Report>()
                    .Include(r => r.Post)
                    .Include(r => r.Reporter)
                    .Include(r => r.Post.Op)
                    .Include(r => r.ReportType)
                    .Where(r => r.Post != null)
                    .Where(r => r.Comment == null)
                    .Where(r => r.Post.DeletionDate == null)
                    .Where(r => r.Post.Id > lastId || lastId == 0)
                    .OrderBy(r => r.Post.Id)
                    .ToList();
            }
        }

        public List<Report> GetReportedComments(int lastId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Report>()
                    .Include(r => r.Post)
                    .Include(r => r.Reporter)
                    .Include(r => r.Comment.User)
                    .Include(r => r.ReportType)
                    .Where(r => r.Post == null)
                    .Where(r => r.Comment != null)
                    .Where(r => r.Post.DeletionDate == null)
                    .Where(r => r.Post.Id > lastId || lastId == 0)
                    .OrderBy(r => r.Post.Id)
                    .ToList();
            }
        }

        public void AddReport(Report report)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(report);
            }
        }
    }
}