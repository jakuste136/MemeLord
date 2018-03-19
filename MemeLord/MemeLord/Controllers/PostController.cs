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

        [Route("getMany/{getManyPostsRequest}")]
        public GetManyPostsResponse GetManyPosts(GetManyPostsRequest request)
        {
            return _postRepository.GetManyPosts(request);
        }
    }
}
