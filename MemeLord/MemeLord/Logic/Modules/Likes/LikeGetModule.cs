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
        Like GetLike(int postId);
    }

    public class LikeGetModule : ILikeGetModule
    {
        private readonly ILikeRepository _likeRepository;

        public LikeGetModule(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public Like GetLike(int postId)
        {
            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";
            return _likeRepository.GetLikeByPostId(postId, Int32.Parse(userId));
        }
    }
}