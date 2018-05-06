using AutoMapper;
using MemeLord.DataObjects.Dto.ReportDtos;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping.Reports
{
    public interface IReportedCommentMapper : IMapper<Report, ReportedCommentDto>
    {
    }

    public class ReportedCommentMapper : Mapper<Report, ReportedCommentDto>, IReportedCommentMapper
    {
        public override IMappingExpression<Report, ReportedCommentDto> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(dto => dto.Username, map => map.MapFrom(report => report.Comment.User.Username))
                .ForMember(dto => dto.Text, map => map.MapFrom(report => report.Comment.Text))
                .ForMember(dto => dto.CreationDate, map => map.MapFrom(report => report.Comment.CreationDate))
                .ForMember(dto => dto.Description, map => map.MapFrom(report => report.ReportType.Description))
                .ForMember(dto => dto.CommentId, map => map.MapFrom(report => report.Comment.Id));
        }
    }
}