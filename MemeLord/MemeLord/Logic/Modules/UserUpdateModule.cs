using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules
{
    public interface IUserUpdateModule
    {
        void UpdateUser(UserDto userDto);
    }

    public class UserUpdateModule : IUserUpdateModule
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateModule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UpdateUser(UserDto userDto)
        {
        }
    }
}