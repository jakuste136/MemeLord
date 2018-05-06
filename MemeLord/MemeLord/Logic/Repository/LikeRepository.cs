using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface ILikeRepository
    {
        void AddLike(Like like);
        void UpdateLike(Like like);
        Like GetLikeByPostId(int postId, int userId);
    }

    public class LikeRepository : ILikeRepository
    {
        public void AddLike(Like like)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(like);
            }
        }

        public Like GetLikeByPostId(int postId, int userId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Like>()
                    .Include(l => l.Post)
                    .SingleOrDefault(l => l.Post.Id == postId && l.User.Id == userId);
            }
        }

        public void UpdateLike(Like like)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Update(like);
            }
        }
    }
}