using MemeLord.DataObjects.Response;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules.Comments;
using MemeLord.Logic.Modules;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {
        private readonly IGetCommentsModule _getCommentsModule;
        private readonly IAddCommentsModule _addCommentsModule;
        private readonly IUpdateCommentModule _updateCommentModule;

        public CommentController(IGetCommentsModule getCommentsModule, IAddCommentsModule addCommentsModule, IUpdateCommentModule updateCommentModule)
        {
            _getCommentsModule = getCommentsModule;
            _addCommentsModule = addCommentsModule;
            _updateCommentModule = updateCommentModule;
        }

        [Route("{id}")]
        public CommentDto GetById(int id)
        {
            return _getCommentsModule.GetComment(id);
        }
        
        [HttpGet]
        public GetCommentsResponse GetManyComments([FromUri] int postId, [FromUri] int lastId, [FromUri] int count)
        {
            return _getCommentsModule.GetPostComments(postId, lastId, count);
        }

        [Route("best")]
        [HttpGet]
        public GetBestCommentsResponse GetBestComments([FromUri] int postId, [FromUri] int count)
        {
            return _getCommentsModule.GetBestComments(postId, count);
        }
        
        [HttpPost]
        public void AddComment(AddCommentRequest addCommentRequest)
        {
            _addCommentsModule.AddComment(addCommentRequest);
        }

        [Route("delete")]
        [HttpGet]
        public void DeleteComment([FromUri] int id)
        {
            _updateCommentModule.DeleteComment(id);
        }
    }
}