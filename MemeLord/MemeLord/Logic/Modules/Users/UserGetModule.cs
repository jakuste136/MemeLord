using System.Collections.Generic;
using MemeLord.DataObjects.Response;
using MemeLord.Logic.Mapping.Users;
using MemeLord.Logic.Repository;

namespace MemeLord.Logic.Modules.Users
{
    public interface IUserGetModule
    {
        GetUserResponse GetUserById(int id);
        IList<GetUserResponse> GetAllUsers();
    }

    public class UserGetModule : IUserGetModule
    {
        private readonly IUserRepository _userRepository;
        private readonly IGetUserResponseMapper _responseMapper;

        public UserGetModule(IUserRepository userRepository, IGetUserResponseMapper responseMapper)
        {
            _userRepository = userRepository;
            _responseMapper = responseMapper;
        }

        public GetUserResponse GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return _responseMapper.Map(user);
        }

        public IList<GetUserResponse> GetAllUsers()
        {
            var userList = _userRepository.GetUsers();
            return _responseMapper.Map(userList);
        }
    }
}