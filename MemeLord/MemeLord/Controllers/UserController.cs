using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using JsonPatch;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Modules;
using MemeLord.Logic.Repository;
using MemeLord.Models;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        //private readonly IUserUpdateModule _userUpdateModule;

        public UserController(IUserRepository userQueries)
        {
            _userRepository = userQueries;
        }

        [Route("get")]
        [HttpGet]
        public IList<User> Get()
        {
            return _userRepository.GetUsers().ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public User Get(int id)
        {
            return _userRepository.GetUserById(id);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return StatusCode(HttpStatusCode.UnsupportedMediaType);
            _userRepository.SaveUser(userDto);
            return StatusCode(HttpStatusCode.Accepted);
        }

        [Route("{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, JsonPatchDocument<User> userPatch)
        {
            var userToUpdate = _userRepository.GetUserById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            userPatch.ApplyUpdatesTo(userToUpdate);
            _userRepository.SaveUser(userToUpdate);
            return Ok(userToUpdate);
        }
    }
}
