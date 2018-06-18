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
        List<Post> GetUserPosts(int lastId, int count, string authorName);
        List<Post> GetTopPosts(int lastId, int count);
        void AddPost(Post post);
        Post GetRandomPost();
        void UpdatePost(Post post);
        int GetNumberOfDeletedByUserId(int userId);
        List<Post> GetUserPosts(string username);
        Post GetBestUserPost(string username);
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

        public List<Post> GetTopPosts(int lastId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(p => p.Op)
                    .OrderByDescending(p => p.Rating)
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
                    .FirstOrDefault();
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

        public int GetNumberOfDeletedByUserId(int userId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(c => c.Op)
                    .Where(c => c.Op.Id == userId || userId == 0)
                    .Where(c => c.DeletionDate != null)
                    .Count();
            }
        }

        public List<Post> GetUserPosts(int lastId, int count, string authorName)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(p => p.Op)
                    .OrderByDescending(p => p.CreationDate)
                    .Where(p => p.Op.Username.Equals(authorName))
                    .Where(p => p.Id < lastId || lastId == 0)
                    .Where(p => p.DeletionDate == null)
                    .Limit(count)
                    .ToList();
            }
        }

        public List<Post> GetUserPosts(string username)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(p => p.Op)
                    .Where(p => p.Op.Username.Equals(username))
                    .Where(p => p.DeletionDate == null)
                    .ToList();
            }
        }

        public Post GetBestUserPost(string username)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Post>()
                    .Include(p => p.Op)
                    .OrderByDescending(p => p.Rating)
                    .FirstOrDefault(p => p.Op.Username.Equals(username));
            }
        }
    }
}