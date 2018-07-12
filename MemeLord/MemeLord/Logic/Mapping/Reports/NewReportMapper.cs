using System;
using System.Security.Claims;
using AutoMapper;
using MemeLord.Models;
using MemeLord.DataObjects.Request.Reports;
using MemeLord.Logic.Extensions;

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
                .ForMember(report => report.Post, map => map.ResolveUsing(GetPostOrDefault))
                .ForMember(report => report.Comment, map => map.ResolveUsing(GetCommentOrDefault))
                .ForMember(report => report.Reporter, map => map.ResolveUsing(request => GetReporter()))
                .ForMember(report => report.ReportDate, map => map.ResolveUsing(request => DateTime.UtcNow))
                .ForPath(report => report.ReportType.Id, map => map.MapFrom(request => request.ReportTypeId));
        }

        private User GetReporter()
        {
            return new User
            {
                Id = ClaimsPrincipalWrapper.GetIdFromClaim()
            };
        }

        private Post GetPostOrDefault(AddReportRequest request)
        {
            return request.PostId != null 
                ? new Post { Id = request.PostId.Value } 
                : null;
        }

        private Comment GetCommentOrDefault(AddReportRequest request)
        {
            return request.CommentId != null 
                ? new Comment { Id = request.CommentId.Value } 
                : null;
        }
    }
}