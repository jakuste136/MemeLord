using MemeLord.Logic.Database;
using MemeLord.Models;
using System;
using System.Collections.Generic;

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
                var masterComments = db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .Include(c => c.Post)
                    .Include(c => c.User)
                    .OrderByDescending(c => c.CreationDate)
                    .Where(c => c.Post.Id == postId)
                    .Where(c => c.Id > lastId)
                    .Where(c => c.MasterComment == null)
                    .Where(c => c.DeletionDate == null)
                    .Limit(count)
                    .ToList();

                List<Comment> answers = new List<Comment>();
                foreach (var masterComment in masterComments ?? new List<Comment>())
                {
                    try
                    {
                        answers.InsertRange(answers.Count,
                            db.Query<Comment>()
                            .Include(c => c.MasterComment)
                            .Include(c => c.Post)
                            .Include(c => c.User)
                            .OrderByDescending(c => c.CreationDate)
                            .Where(c => c.Post.Id == postId)
                            .Where(c => c.MasterComment.Id == masterComment.Id)
                            .Where(c => c.DeletionDate == null)
                            .ToList()
                            );
                    }
                    catch (ArgumentNullException e) { /*when query returns null*/}
                }
                
                masterComments.InsertRange(masterComments.Count, answers);
                
                return masterComments;
            }
        }
    }
}