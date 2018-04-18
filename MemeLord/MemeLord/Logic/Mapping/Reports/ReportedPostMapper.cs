using AutoMapper;
using MemeLord.DataObjects.Dto.ReportDtos;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Reports
{
    public interface IReportedPostMapper : IMapper<Report, ReportedPostDto>
    {
    }

    public class ReportedPostMapper : Mapper<Report, ReportedPostDto>, IReportedPostMapper
    {
        public override IMappingExpression<Report, ReportedPostDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dto => dto.Username, map => map.MapFrom(report => report.Post.Op.Username))
                .ForMember(dto => dto.Title, map => map.MapFrom(report => report.Post.Title))
                .ForMember(dto => dto.Image, map => map.MapFrom(report => report.Post.Image))
                .ForMember(dto => dto.CreationDate, map => map.MapFrom(report => report.Post.CreationDate))
                .ForMember(dto => dto.Description, map => map.MapFrom(report => report.ReportType.Description))
                .ForMember(dto => dto.PostId, map => map.MapFrom(report => report.Post.Id));
        }
    }
}