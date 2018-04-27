using MemeLord.DataObjects.Response;
using MemeLord.Logic.Modules;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MemeLord.DataObjects.Response.Posts;
using MemeLord.Logic.Modules.Posts;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _postRepository;
        private readonly IGetPostsModule _getPostsModule;
        private readonly IAddPostModule _addPostModule;
        private readonly IGetRandomPostModule _getRandomPostModule;
        private readonly IUpdatePostModule _updatePostModule;

        public PostController(IPostRepository postRepository, IGetPostsModule getPostsModule, IAddPostModule addPostModule, IGetRandomPostModule getRandomPostModule, IUpdatePostModule updatePostModule)
        {
            _postRepository = postRepository;
            _getPostsModule = getPostsModule;
            _addPostModule = addPostModule;
            _getRandomPostModule = getRandomPostModule;
            _updatePostModule = updatePostModule;
        }

        [Route("{id}")]
        public Post GetById(int id)
        {
            return _postRepository.GetPostById(id);
        }

        [Route("random")]
        [HttpGet]
        public GetRandomPostResponse GetRandomPost()
        {
            return _getRandomPostModule.GetRandomPost();
        }

        [HttpGet]
        public GetPostsResponse GetManyPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getPostsModule.GetPosts(lastId, count);
        }

        [HttpPost]
        public HttpResponseMessage AddPost()
        {
            return _addPostModule.AddPost(Request);
        }

        [Route("delete")]
        [HttpGet]
        public void DeletePost([FromUri] int id)
        {
            _updatePostModule.DeletePost(id);
        }
    }
}
