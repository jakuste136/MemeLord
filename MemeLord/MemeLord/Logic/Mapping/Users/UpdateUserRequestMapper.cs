﻿using AutoMapper;
using MemeLord.DataObjects.Request;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Users
{
    public interface IUpdateUserRequestMapper
    {
        User Map(UpdateUserRequest source);
    }

    public class UpdateUserRequestMapper : Mapper<UpdateUserRequest, User>, IUpdateUserRequestMapper
    {
        public override IMappingExpression<UpdateUserRequest, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(usr => usr.Hash, map => map.Ignore())
                .ForMember(usr => usr.Id, map => map.Ignore());
        }
    }
}