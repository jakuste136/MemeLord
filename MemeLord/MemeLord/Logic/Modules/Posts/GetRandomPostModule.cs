using MemeLord.DataObjects.Response.Posts;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Posts
{
    public interface IGetRandomPostModule
    {
        GetRandomPostResponse GetRandomPost();
    }

    public class GetRandomPostModule : IGetRandomPostModule
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostMapper _postMapper;

        public GetRandomPostModule(IPostRepository postRepository, IPostMapper postMapper)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
        }

        public GetRandomPostResponse GetRandomPost()
        {
            var randomPost = _postRepository.GetRandomPost();

            return new GetRandomPostResponse
            {
                Post = _postMapper.Map(randomPost)
            };
        }
    }
}