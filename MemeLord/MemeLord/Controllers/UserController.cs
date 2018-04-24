using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using JsonPatch;
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
            // TODO Mateusz: Remove only for test purposes
            var username = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "";

            return _userGetModule.GetAllUsers();
        }

        [Route("get-self")]
        [HttpGet, Authorize(Roles = "User")]
        public GetUserResponse GetSelf()
        {
            var username = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? "";
            return _userGetModule.GetUserByName(username);
        }

        [Route("{username}")]
        [HttpGet]
        public GetUserResponse Get(string username)
        {
            return _userGetModule.GetUserByName(username);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] AddUserRequest request)
        {
            return _userAddModule.AddUser(request);
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] UpdateUserRequest request)
        {
            return _userUpdateModule.UpdateUser(request);
        }

        [Route("{id}")]
        [HttpPatch, Authorize]
        public HttpResponseMessage Patch(int id, JsonPatchDocument<User> userPatch)
        {
            return _userUpdateModule.UpdateUser(id, userPatch);
        }
    }
}
