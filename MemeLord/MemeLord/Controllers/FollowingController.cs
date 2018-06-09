﻿using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Modules.Followings;
using System.Net.Http;
using System.Web.Http;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/following")]
    public class FollowingController: ApiController
    {
        private readonly IGetFollowingModule _getFollowingModule;
        private readonly IUpsertFollowingModule _upsertFollowingModule;

        public FollowingController(IGetFollowingModule getFollowingModule,
            IUpsertFollowingModule upsertFollowingModule)
        {
            _getFollowingModule = getFollowingModule;
            _upsertFollowingModule = upsertFollowingModule;
        }

        [HttpGet]
        public FollowingDto Get()
        {
            return _getFollowingModule.GetFollowing("mateher");
        }

        [HttpGet, Authorize]
        public FollowingDto Get([FromUri] string authorName)
        {
            return _getFollowingModule.GetFollowing(authorName);
        }

        [HttpPost, Authorize]
        public HttpResponseMessage Post([FromBody] FollowRequest request)
        {
            return _upsertFollowingModule.UpsertFollowing(request);
        }
    }
}