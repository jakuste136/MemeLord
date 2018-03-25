using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using JsonPatch;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Modules.Users;
using MemeLord.Logic.Repository;
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

        [HttpGet]
        public IList<UserDto> Get()
        {
            return _userGetModule.GetAllUsers();
        }

        [Route("{id}")]
        [HttpGet]
        public UserDto Get(int id)
        {
            return _userGetModule.GetUserById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] UserDto userDto)
        {
            return _userAddModule.AddUser(userDto);
        }

        [Route("{id}")]
        [HttpPatch]
        public HttpResponseMessage Patch(int id, JsonPatchDocument<User> userPatch)
        {
            return _userUpdateModule.UpdateUser(id, userPatch);
        }
    }
}
