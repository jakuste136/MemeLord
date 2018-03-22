using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface IPostRepository
    {
        Post GetPostById(int id);
        List<Post> GetManyPosts(int lastId, int count);
    }

    public class PostRepository : IPostRepository
    {
        public Post GetPostById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var result = db.Query<Post>()
                    .Include(p => p.Op)
                    .SingleOrDefault(p => p.Id == id);

                return result;
            }
        }

        public List<Post> GetManyPosts(int lastId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(p => p.Op)
                    .OrderByDescending(p => p.CreationDate)
                    .Where(p => p.Id < lastId || lastId == 0)
                    .Where(p => p.DeletionDate == null)
                    .Limit(count)
                    .ToList();
            }
        }
    }
}