﻿using System;
using System.Security.Claims;
using AutoMapper;
using MemeLord.Models;
using MemeLord.DataObjects.Request;
using MemeLord.Logic.Extensions;

namespace MemeLord.Logic.Mapping.CommentMapping
{
    public interface INewCommentMapper : IMapper<AddCommentRequest, Comment>
    {
    }

    public class NewCommentMapper : Mapper<AddCommentRequest, Comment>, INewCommentMapper
    {
        public override IMappingExpression<AddCommentRequest, Comment> CreateMap(IMapperConfigurationExpression cfg)
        {
            return base.CreateMap(cfg)
                .ForMember(comment => comment.MasterComment, map => map.ResolveUsing(request => GetMasterComment(request.MasterCommentId)))
                .ForPath(comment => comment.Post.Id, map => map.MapFrom(request => request.PostId))
                .ForPath(comment => comment.User.Id, map => map.MapFrom(request => GetUserId()))
                .ForMember(comment => comment.Answers, map => map.Ignore())
                .ForMember(comment => comment.DeletionDate, map => map.Ignore())
                .ForMember(comment => comment.CreationDate, map => map.MapFrom(request => DateTime.Now));
        }

        private Comment GetMasterComment(int? masterCommentId)
        {
            if (masterCommentId == null)
                return null;

            return new Comment
            {
                Id = masterCommentId.Value
            };
        }

        private int GetUserId()
        {
            return Convert.ToInt32(ClaimsPrincipalWrapper.GetFromClaim(ClaimTypes.NameIdentifier));
        }
    }
}