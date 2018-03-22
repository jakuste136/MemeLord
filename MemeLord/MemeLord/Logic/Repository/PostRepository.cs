using MemeLord.Logic.Database;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Mapping;
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
        GetManyPostsResponse GetManyPosts(GetManyPostsRequest request);
    }

    public class PostRepository : IPostRepository
    {
        private readonly PostMapper _mapper;

        public PostRepository(PostMapper mapper)
        {
            _mapper = mapper;
        }

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

        public GetManyPostsResponse GetManyPosts(GetManyPostsRequest request)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var queryResult = db.Query<Post>().OrderByDescending(p => p.CreationDate)
                               .Where(p => p.Id < request.LastId || request.LastId == 0)
                               .Limit(request.Count)
                               .ToList();

                var result = MapEntityToDto(queryResult);

                return result;
            }
        }   
        
        private GetManyPostsResponse MapEntityToDto(IEnumerable<Post> postsList)
        {
            var lastId = postsList.LastOrDefault().Id;
            var postDtosList = _mapper.MapList(postsList);
            return new GetManyPostsResponse
            {
                PostsList = postDtosList,
                LastId = lastId
            };
        }
    }
}