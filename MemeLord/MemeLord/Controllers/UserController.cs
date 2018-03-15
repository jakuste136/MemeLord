using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MemeLord.Logic.Queries;
using MemeLord.Models;

namespace MemeLord.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserQueries _userQueries;

        public UserController(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        [Route("get")]
        [HttpGet]
        public IList<Users> Get()
        {
            return _userQueries.GetUsers().ToList();
        }

        [Route("get/{id}")]
        [HttpGet]
        public Users Get(int id)
        {
            return _userQueries.GetUserById(id);
        }
    }
}
