using MemeLord.DataObjects.Response;
using System.Web.Http;
using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules.Comments;
using MemeLord.Logic.Modules;
using MemeLord.Logic.Modules.Reports;
using System.Net.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {
        private readonly IGetCommentsModule _getCommentsModule;
        private readonly IAddCommentsModule _addCommentsModule;
        private readonly IUpdateCommentModule _updateCommentModule;
        private readonly IAutoBanModule _autoBanModule;

        public CommentController(IGetCommentsModule getCommentsModule, IAddCommentsModule addCommentsModule, IUpdateCommentModule updateCommentModule, IAutoBanModule autoBanModule)
        {
            _getCommentsModule = getCommentsModule;
            _addCommentsModule = addCommentsModule;
            _updateCommentModule = updateCommentModule;
            _autoBanModule = autoBanModule;
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

        [HttpPost, Authorize(Roles = "Member, Admin")]
        public AddCommentResponse AddComment(AddCommentRequest addCommentRequest)
        {
            return new AddCommentResponse
            {
                Comment = _addCommentsModule.AddComment(addCommentRequest)
            };
        }

        [Route("update-rating")]
        [HttpPut, Authorize]
        public HttpResponseMessage UpdateCommentRating([FromBody] UpdateCommentRatingRequest request)
        {
            return _updateCommentModule.UpdateCommentRating(request);
        }

        [Route("delete")]
        [HttpGet, Authorize(Roles = "Member, Admin")]
        public void DeleteComment([FromUri] int id)
        {
            _updateCommentModule.DeleteComment(id);
            //check if user should be banned; new module with automatic banning including user, comment and post repository
            _autoBanModule.BanIfDeserveByCommentId(id);  //1. fetch userId ( CommentRepository.GetOwnerId() ) -> 2. check if they should be banned ( Comment + PostRepository.GetDeletionsByUser( userId ) >= ReportingConfiguration.MinimumDeletionsNumber; ) -> 3. ban automatically ( UserRepository.BanUser( userId );
            //must add bannedDate to user
        }
    }
}