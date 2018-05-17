﻿using MemeLord.DataObjects.Request;
using MemeLord.DataObjects.Response.Posts;
using MemeLord.Logic.Modules.Posts;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Net.Http;
using System.Web.Http;
using MemeLord.DataObjects.Dto;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostRepository _postRepository;
        private readonly IGetPostsModule _getPostsModule;
        private readonly IAddPostModule _addPostModule;
        private readonly IGetRandomPostModule _getRandomPostModule;
        private readonly IPostUpdateModule _postUpdateModule;
        private readonly IUpdatePostModule _updatePostModule;

        public PostController(IPostRepository postRepository, 
            IGetPostsModule getPostsModule, 
            IAddPostModule addPostModule, 
            IGetRandomPostModule getRandomPostModule, 
            IPostUpdateModule postUpdateModule,
            IUpdatePostModule updatePostModule)
        {
            _postRepository = postRepository;
            _getPostsModule = getPostsModule;
            _addPostModule = addPostModule;
            _postUpdateModule = postUpdateModule;
            _getRandomPostModule = getRandomPostModule;
            _updatePostModule = updatePostModule;
        }

        [Route("{id}")]
        public PostDto GetById(int id)
        {
            return _getPostsModule.GetPost(id);
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

        [HttpPost, Authorize]
        public HttpResponseMessage AddPost()
        {
            return _addPostModule.AddPost(Request);
        }

        [Route("delete")]
        [HttpGet, Authorize]
        public void DeletePost([FromUri] int id)
        {
            _updatePostModule.DeletePost(id);
        }
        
        [Route("update-rating")]
        [HttpPut, Authorize]
        public HttpResponseMessage UpdatePostRating([FromBody] UpdatePostRatingRequest request)
        {
            return _postUpdateModule.UpdatePostRating(request);
        }

        [Route("top")]
        [HttpGet]
        public GetPostsResponse GetTopPosts([FromUri] int lastId, [FromUri] int count)
        {
            return _getPostsModule.GetTopPosts(lastId, count);
        }
    }
}
