using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using JsonPatch;
using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Request;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Modules.Users;
using MemeLord.Models;

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

        [HttpGet, Authorize(Roles = "User")]
        public IList<GetUserResponse> Get()
        {
            return _userGetModule.GetAllUsers();
        }

        [Route("{id}")]
        [HttpGet]
        public GetUserResponse Get(int id)
        {
            return _userGetModule.GetUserById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] AddUserRequest request)
        {
            return _userAddModule.AddUser(request);
        }

        [Route("{id}")]
        [HttpPatch]
        public HttpResponseMessage Patch(int id, JsonPatchDocument<User> userPatch)
        {
            return _userUpdateModule.UpdateUser(id, userPatch);
        }
    }
}
