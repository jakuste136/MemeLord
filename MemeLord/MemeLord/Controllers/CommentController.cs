﻿using MemeLord.Logic.Repository;
using MemeLord.Logic.Request;
using MemeLord.Logic.Response;
using MemeLord.Models;
using System.Web.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IGetCommentsModule _getCommentsModule;

        public CommentController(ICommentRepository commentRepository, IGetCommentsModule getCommentsModule)
        {
            _commentRepository = commentRepository;
            _getCommentsModule = getCommentsModule;
        }

        [Route("get/{id}")]
        public Comment GetById(int id)
        {
            return _commentRepository.GetCommentById(id);
        }

        [Route("get-comments")]
        public GetPostCommentsResponse GetManyComments([FromUri] int postId, [FromUri] int lastId, [FromUri] int count)
        {
            return _getCommentsModule.GetPostComments(postId, lastId, count);
        }

    }
}