using System;
using System.Collections.Generic;
using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface IPostRepository
    {
        Post GetPostById(int id);
        List<Post> GetPosts(int lastId, int count);
        void AddPost(Post post);
        Post GetRandomPost();
        void UpdatePost(Post post);
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

        public List<Post> GetPosts(int lastId, int count)
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

        public Post GetRandomPost()
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var postsCount = db.Query<Post>()
                    .Where(p => p.DeletionDate == null)
                    .Count();

                var randomIndex = new Random().Next(0, postsCount);

                return db.Query<Post>()
                    .Include(p => p.Op)
                    .Where(p => p.DeletionDate == null)
                    .Limit(randomIndex, 1)
                    .First();
            }
        }

        public void AddPost(Post post)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(post);
            }
        }

        public void UpdatePost(Post post)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(post);
            }
        }
    }
}