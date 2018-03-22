using MemeLord.Logic.Database;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Request;
using MemeLord.Logic.Response;
using MemeLord.Models;
using System.Collections.Generic;
using System.Linq;

namespace MemeLord.Logic.Repository
{
    public interface IPostRepository
    {
        Post GetPostById(int id);
        GetManyPostsResponse GetManyPosts(int lastId, int count);
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

        public GetManyPostsResponse GetManyPosts(int lastId, int count)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var queryResult = db.Query<Post>().OrderByDescending(p => p.CreationDate)
                               .Where(p => p.Id < lastId || lastId == 0)
                               .Limit(count)
                               .ToList();

                var result = MapEntityToDto(queryResult);

                return result;
            }
        }   
        
        private GetManyPostsResponse MapEntityToDto(IEnumerable<Post> postsList)
        {
            var lastId = postsList.LastOrDefault().Id;
            var postDtosList = new List<PostDto>();
            foreach(var post in postsList)
            {
                postDtosList.Add(new PostDto
                {
                    Title = post.Title,
                    Image = post.Image,
                    Rating = post.Rating,
                    CreationDate = post.CreationDate,
                    DeletionDate = post.DeletionDate
                });
            }
            return new GetManyPostsResponse
            {
                PostsList = postDtosList,
                LastId = lastId
            };
        }
    }
}