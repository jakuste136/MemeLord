using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Repository
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string authorName, int userId);
        void UpsertFollowing(Following following);
    }

    public class FollowingRepository : IFollowingRepository
    {
        public Following GetFollowing(string authorName, int userId)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                return db.Query<Following>()
                    .SingleOrDefault(f => f.Followed.Username == authorName && f.Follower.Id == userId);
            }
        }

        public void UpsertFollowing(Following following)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                db.Save(following);
            }
        }
    }
}