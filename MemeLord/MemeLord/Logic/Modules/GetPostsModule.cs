using System.Collections.Generic;
using System.Linq;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;
using MemeLord.Models;

namespace MemeLord.Logic.Modules
{
    public interface IGetPostsModule
    {
        GetPostsResponse GetPosts(int lastId, int count);
    }

    public class GetPostsModule : IGetPostsModule
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostMapper _postMapper;

        public GetPostsModule(IPostRepository postRepository, IPostMapper postMapper)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
        }

        public GetPostsResponse GetPosts(int lastId, int count)
        {
            var posts = _postRepository.GetManyPosts(lastId, count);
            
            var postDtos = _postMapper.Map(posts);

            return new GetPostsResponse
            {
                LastId = GetLastId(posts),
                PostsList = postDtos
            };
        }

        private static int GetLastId(List<Post> posts)
        {
            return posts.Count == 0 ? 0 : posts.Last().Id;
        }
    }
}