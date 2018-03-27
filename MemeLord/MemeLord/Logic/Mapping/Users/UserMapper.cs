using System;
using System.Collections.Generic;
using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Users
{
    [Obsolete]
    public interface IUserMapper
    {
        UserDto Map(User source);
        IList<UserDto> Map(IList<User> sourceItemsList);
    }

    [Obsolete]
    public class UserMapper : Mapper<User, UserDto>, IUserMapper
    {
        public override IMappingExpression<User, UserDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(usr => usr.Password, map => map.UseValue(""));
        }
    }
}