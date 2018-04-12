using MemeLord.DataObjects.Response;
using MemeLord.Logic.Modules;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _postRepository;
        private readonly IGetPostsModule _getPostsModule;
        private readonly IAddPostsModule _addPostsModule;

        public PostController(IPostRepository postRepository, IGetPostsModule getPostsModule, IAddPostsModule addPostsModule)
        {
            _postRepository = postRepository;
            _getPostsModule = getPostsModule;
            _addPostsModule = addPostsModule;
        }

        [Route("{id}")]
        public Post GetById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        [HttpGet]
        public GetPostsResponse GetManyPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getPostsModule.GetPosts(lastId, count);
        }

        [HttpPost]
        public HttpResponseMessage AddPost()
        {
            return _addPostsModule.AddPost(Request);
        }
    }
}
