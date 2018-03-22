using MemeLord.Logic.Database;
using System.Collections.Generic;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface ICommentQueries
    {
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetPostComments(int postId);
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
        
        public IEnumerable<Comment> GetPostComments(int postId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Comment>().OrderByDescending(c => c.CreationDate).
                    Where(c => c.Post.Id == postId).ToEnumerable();
            }
        }
    }
}