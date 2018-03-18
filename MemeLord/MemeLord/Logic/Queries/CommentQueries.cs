using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface ICommentQueries
    {
        Comment GetCommentById(int id);
    }

    public class CommentQueries : ICommentQueries
    {
        public Comment GetCommentById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var data = db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .SingleOrDefault(c => c.Id == id);

                return data;
            }
        }
    }
}