using System.Collections.Generic;
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

        public UserController(IUserUpdateModule userUpdateModule, IUserAddModule userAddModule, IUserGetModule userGetModule)
        {
            _userUpdateModule = userUpdateModule;
            _userAddModule = userAddModule;
            _userGetModule = userGetModule;
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
    }
}
