using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface ILikeRepository
    {
        void AddLike(Like like);
        void UpdateLike(Like like);
        Like GetLikeByPostId(int postId, int userId);
        Like GetLikeByCommentId(int commentId, int userId);
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
                    .Include(l => l.User)
                    .SingleOrDefault(l => l.Post.Id == postId && l.User.Id == userId);
            }
        }

        public Like GetLikeByCommentId(int commentId, int userId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Like>()
                    .Include(l => l.Comment)
                    .Include(l => l.User)
                    .SingleOrDefault(l => l.Comment.Id == commentId && l.User.Id == userId);
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