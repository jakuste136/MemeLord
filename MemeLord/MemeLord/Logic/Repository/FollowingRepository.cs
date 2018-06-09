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
                    .Include(p => p.Followed)
                    .Include(p => p.Follower)
                    .SingleOrDefault(f => f.Followed.Username == authorName && f.Follower.Id == userId);
            }
        }

        public void UpsertFollowing(Following following)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var result =
                    db.Query<Following>()
                        .Include(p => p.Followed)
                        .Include(p => p.Follower)
                        .SingleOrDefault(f => f.Followed.Id == following.Followed.Id && f.Follower.Id == following.Follower.Id);
                db.Execute(
                    result != null
                        ? $"UPDATE [Followings] SET [Active] = '{following.Active}' WHERE [FollowerId] = {following.Follower.Id} AND [FollowedId] = {following.Followed.Id}"
                        : $"INSERT INTO [Followings] VALUES ({following.Followed.Id}, {following.Follower.Id}, '{following.Active}')");
                //db.Save(following);
            }
        }
    }
}