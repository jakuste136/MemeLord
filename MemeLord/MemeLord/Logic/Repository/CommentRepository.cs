using MemeLord.Logic.Database;
using MemeLord.Models;
using System.Collections.Generic;

namespace MemeLord.Logic.Repository
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetManyComments(int postId, int lastId, int count);
        List<Comment> GetBestComments(int postId, int count);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
    }

    public class CommentRepository : ICommentRepository
    {
        public Comment GetCommentById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var comment = db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .SingleOrDefault(c => c.Id == id);

                var answers = db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .Where(c => c.MasterComment.Id == id)
                    .ToList();

                comment.Answers = answers;
                return comment;
            }
        }

        // mozliwe ze trzeba bedzie popracowac nad wydajnoscia, jak sie pojawią problemy
        public List<Comment> GetManyComments(int postId, int lastId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var masterComments = db.Query<Comment>()
                    .Include(c => c.User)
                    .Include(p => p.Post)
                    .OrderByDescending(c => c.CreationDate)
                    .Where(c => c.Post.Id == postId)
                    .Where(c => c.Id < lastId || lastId == 0)
                    .Where(c => c.MasterComment == null)
                    .Where(c => c.DeletionDate == null)
                    .Limit(count)
                    .ToList();

                foreach (var masterComment in masterComments)
                {
                    var answers = db.Query<Comment>()
                        .Include(c => c.User)
                        .Include(c => c.MasterComment)
                        .OrderBy(c => c.CreationDate)
                        .Where(c => c.MasterComment.Id == masterComment.Id)
                        .Where(c => c.DeletionDate == null)
                        .ToList();

                    masterComment.Answers = answers;
                }
                return masterComments;
            }
        }

        public List<Comment> GetBestComments(int postId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var result = db.Query<Comment>()
                    .Include(c => c.User)
                    .Include(p => p.Post)
                    .OrderByDescending(c => c.Rating)
                    .Where(c => c.Post.Id == postId)
                    .Where(c => c.DeletionDate == null)
                    .Limit(count)
                    .ToList();

                return result;
            }
        }
        
        public void AddComment(Comment comment)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(comment);
            }
        }

        public void UpdateComment(Comment comment)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(comment);
            }
        }
    }
}