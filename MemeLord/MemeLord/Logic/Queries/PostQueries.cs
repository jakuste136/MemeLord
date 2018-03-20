using MemeLord.Logic.Database;
using MemeLord.Models;

namespace MemeLord.Logic.Queries
{
    public interface IPostQueries
    {
        Post GetPostById(int id);
    }

    public class PostQueries : IPostQueries
    {
        public Post GetPostById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var data = db.Query<Post>()
                    .Include(p => p.Op)
                    .SingleOrDefault(p => p.Id == id);

                return data;
            }
        }
    }
}