using MemeLord.Logic.Database;
using MemeLord.Models;
using System.Collections.Generic;
using MemeLord.Logic.Queries;
using System.Linq;
using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.DataObjects.Response;

namespace MemeLord.Logic.Repository
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetManyComments(int postId, int lastId, int count);
    }

    public class CommentRepository : ICommentRepository
    {
        public Comment GetCommentById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .SingleOrDefault(c => c.Id == id);
            }
        }

        public List<Comment> GetManyComments(int postId, int lastId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .OrderByDescending(c => c.CreationDate)
                    .Where(c => c.Post.Id == postId)
                    .Where(c => c.Id > lastId)
                    .Where(c => c.DeletionDate == null)
                    .Limit(count)
                    .ToList();
            }

        }

    }
}