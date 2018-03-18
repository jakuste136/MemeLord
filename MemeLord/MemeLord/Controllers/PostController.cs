using System.Web.Http;
using MemeLord.Logic.Queries;
using MemeLord.Models;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostQueries _postQueries;

        public PostController(IPostQueries postQueries)
        {
            _postQueries = postQueries;
        }

        [Route("get/{id}")]
        public Post Get(int id)
        {
            return _postQueries.GetPostById(id);
        }
    }
}
