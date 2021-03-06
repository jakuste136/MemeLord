﻿using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using MemeLord.DataObjects.Request;
using MemeLord.DataObjects.Response;
using MemeLord.DataObjects.Response.UserResponses;
using MemeLord.Logic.Modules.Users;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserUpdateModule _userUpdateModule;
        private readonly IUserAddModule _userAddModule;
        private readonly IUserGetModule _userGetModule;
        private readonly IUserBanModule _userBanModule;

        public UserController(IUserUpdateModule userUpdateModule, IUserAddModule userAddModule, IUserGetModule userGetModule, IUserBanModule userBanModule)
        {
            _userUpdateModule = userUpdateModule;
            _userAddModule = userAddModule;
            _userGetModule = userGetModule;
            _userBanModule = userBanModule;
        }

        [Route("all")]
        [HttpGet, Authorize(Roles = "Member, Admin")]
        public IList<GetUserResponse> GetAll()
        {
            return _userGetModule.GetAllUsers();
        }

        [HttpGet, Authorize(Roles = "Member, Admin")]
        public GetUserResponse Get()
        {
            return _userGetModule.GetSelf();
        }

        [Route("{username}")]
        [HttpGet, Authorize(Roles = "Member, Admin")]
        public GetUserResponse Get(string username)
        {
            return _userGetModule.GetUserByName(username);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] AddUserRequest request)
        {
            return _userAddModule.AddUser(request);
        }

        [HttpPut, Authorize(Roles = "Member, Admin")]
        public HttpResponseMessage Put([FromBody] UpdateUserRequest request)
        {
            return _userUpdateModule.UpdateUser(request);
        }

        [Route("activity")]
        [HttpGet]
        public GetUserActivityResponse GetActivity([FromUri] string username)
        {
            return _userGetModule.GetUserActivity(username);
        }

        [Route("report")]
        [HttpGet, Authorize(Roles = "Admin")]
        public GetUserReportResponse GetUserReport([FromUri] string username, [FromUri] string sex, [FromUri] int status)
        {
            return _userGetModule.GetUserReport(username, sex, status);
        }

        [Route("ban")]
        [HttpPost, Authorize(Roles = "Admin")]
        public HttpResponseMessage PostBanUser([FromBody] BanUserRequest request)
        {
            return _userBanModule.BanUser(request);
        }
    }
}
