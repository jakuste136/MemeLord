using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MemeLord.Logic.Database;
using MemeLord.Logic.Queries;
using MemeLord.Models;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserQueries _userQueries;

        public UserController()
        {
            _userQueries = new UserQueries();
        }

        [Route("get")]
        [HttpGet]
        public IList<User> Get()
        {
            return _userQueries.GetUsers().ToList();
        }

        [Route("get/{id}")]
        [HttpGet]
        public User Get(int id)
        {
            return _userQueries.GetUserById(id);
        }
    }
}
