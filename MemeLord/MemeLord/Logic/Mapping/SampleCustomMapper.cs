using AutoMapper;
using MemeLord.DataObjects.Dto;
using MemeLord.Logic.Authentication;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public interface ISampleCustomMapper
    {
        User Map(UserDto source);
    }

    public class SampleCustomMapper : Mapper<UserDto, User>, ISampleCustomMapper
    {
        public override IMappingExpression<UserDto, User> CreateMap(IMapperConfigurationExpression cfg)
        {
            // maps destination postDto.Title from source user.UserName

            return base.CreateMap(cfg);
        }
    }
}