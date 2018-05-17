﻿using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules.Likes;
using MemeLord.Models;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/like")]
    public class LikeController : ApiController
    {
        private readonly ILikeAddModule _likeAddModule;
        private readonly ILikeGetModule _likeGetModule;

        public LikeController(ILikeAddModule likeAddModule, ILikeGetModule likeGetModule)
        {
            _likeAddModule = likeAddModule;
            _likeGetModule = likeGetModule;
        }

        [Route("get-post")]
        [HttpGet]
        public Like GetPostLikeForUser([FromUri] int postId)
        {
          return _likeGetModule.GetPostLike(postId);
        }

        [Route("get-comment")]
        [HttpGet]
        public Like GetCommentLikeForUser([FromUri] int commentId)
        {
            return _likeGetModule.GetCommentLike(commentId);
        }

        [Route("add-post")]
        [HttpPost]
        public HttpResponseMessage AddPostLike([FromBody] AddLikeRequest request)
        {
            return _likeAddModule.AddPostLike(request);
        }

        [Route("add-comment")]
        [HttpPost]
        public HttpResponseMessage AddCommentLike([FromBody] AddLikeRequest request)
        {
            return _likeAddModule.AddCommentLike(request);
        }
    }
}