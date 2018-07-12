using MemeLord.Logic.Repository;
using MemeLord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MemeLord.Logic.Modules.Likes
{
    public interface ILikeGetModule
    {
        Like GetPostLike(int postId);
        Like GetCommentLike(int commentId);
    }

    public class LikeGetModule : ILikeGetModule
    {
        private readonly ILikeRepository _likeRepository;

        public LikeGetModule(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public Like GetPostLike(int postId)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            return _likeRepository.GetLikeByPostId(postId, Int32.Parse(userId));
        }

        public Like GetCommentLike(int commentId)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            return _likeRepository.GetLikeByCommentId(commentId, Int32.Parse(userId));
        }
    }
}