using MemeLord.Logic.Repository;
using MemeLord.Logic.Request;
using MemeLord.Logic.Response;
using MemeLord.Models;
using System.Web.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [Route("get/{id}")]
        public Post GetById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        [Route("getPosts")]
        [HttpGet]
        public GetManyPostsResponse GetManyPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _postRepository.GetManyPosts(lastId, count);
        }
    }
}
