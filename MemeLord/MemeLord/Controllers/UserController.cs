﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MemeLord.Logic.Dto;
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

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) return StatusCode(HttpStatusCode.UnsupportedMediaType);
            _userQueries.SaveUser(user);
            return StatusCode(HttpStatusCode.Accepted);
        }
    }
}
