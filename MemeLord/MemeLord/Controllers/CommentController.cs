﻿using MemeLord.Logic.Repository;
using MemeLord.DataObjects.Response;
using MemeLord.Models;
using System.Web.Http;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IGetCommentsModule _getCommentsModule;
        private readonly IAddCommentsModule _addCommentsModule;

        public CommentController(ICommentRepository commentRepository, IGetCommentsModule getCommentsModule, IAddCommentsModule addCommentsModule)
        {
            _commentRepository = commentRepository;
            _getCommentsModule = getCommentsModule;
            _addCommentsModule = addCommentsModule;
        }

        [Route("get/{id}")]
        public Comment GetById(int id)
        {
            return _commentRepository.GetCommentById(id);
        }

        [Route("get-comments")]
        [HttpGet]
        public GetCommentsResponse GetManyComments([FromUri] int postId, [FromUri] int lastId, [FromUri] int count)
        {
            return _getCommentsModule.GetPostComments(postId, lastId, count);
        }

        [Route("get-best")]
        [HttpGet]
        public GetCommentsResponse GetBestComments([FromUri] int postId, [FromUri] int count)
        {
            return _getCommentsModule.GetBestComments(postId, count);
        }

        [Route("add-comment")]
        [HttpPost]
        public void AddComment(AddCommentRequest addCommentRequest)
        {
            _addCommentsModule.AddComment(addCommentRequest);
        }
    }
}