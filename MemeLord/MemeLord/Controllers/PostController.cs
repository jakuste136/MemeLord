using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Modules;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _postRepository;
        private readonly IGetPostsModule _getPostsModule;

        public PostController(IPostRepository postRepository, IGetPostsModule getPostsModule)
        {
            _postRepository = postRepository;
            _getPostsModule = getPostsModule;
        }

        [Route("get/{id}")]
        public Post GetById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        [Route("get-posts")]
        [HttpGet]
        public GetPostsResponse GetManyPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getPostsModule.GetPosts(lastId, count);
        }
    }
}
