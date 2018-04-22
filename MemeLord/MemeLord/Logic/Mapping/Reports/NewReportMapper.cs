using AutoMapper;
using MemeLord.Models;
using MemeLord.DataObjects.Request.Reports;

namespace MemeLord.Logic.Mapping.Reports
{
    public interface INewReportMapper : IMapper<AddReportRequest, Report>
    {
    }

    public class NewReportMapper : Mapper<AddReportRequest, Report>, INewReportMapper
    {
        public override IMappingExpression<AddReportRequest, Report> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                //.ForPath(report => report.Comment.Id, map =>
                //{ map.Condition(report => report.Source.CommentId != null); map.MapFrom(request => request.CommentId); })  //not working
                //.ForPath(report => report.Post.Id, map =>
                //{ map.Condition(report => report.Source.PostId != null); map.MapFrom(request => request.PostId); })  //not working
                .ForMember(report => report.Post, map => map.ResolveUsing(request => { return request.PostId != null ? new Post { Id = (int)request.PostId } : null; }))
                .ForMember(report => report.Comment, map => map.ResolveUsing(request => { return request.CommentId != null ? new Comment { Id = (int)request.CommentId } : null; }))
                .ForPath(report => report.Reporter.Id, map => map.MapFrom(request => request.ReporterId))
                .ForPath(report => report.ReportType.Id, map => map.MapFrom(request => request.ReportTypeId));
        }
    }
}