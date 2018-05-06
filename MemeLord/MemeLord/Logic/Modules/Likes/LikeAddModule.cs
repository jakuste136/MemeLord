using MemeLord.DataObjects.Request;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;

namespace MemeLord.Logic.Modules.Likes
{
    public interface ILikeAddModule
    {
        HttpResponseMessage AddLike(AddLikeRequest request);
    }

    public class LikeAddModule : ILikeAddModule
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public LikeAddModule(ILikeRepository likeRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public HttpResponseMessage AddLike(AddLikeRequest request)
        {
            if (request == null)
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            var userId = ClaimsPrincipal.Current.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            var like = _likeRepository.GetLikeByPostId(request.PostId, Int32.Parse(userId));
            if (like == null)
            {
                var preparedLike = PrepareLikeToBeAdded(request.Like, request.PostId, Int32.Parse(userId));
                _likeRepository.AddLike(preparedLike);
            }
            else
            {
                like.Value = request.Like.Value;
                _likeRepository.UpdateLike(like);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private Like PrepareLikeToBeAdded(Like like, int postId, int userId)
        {
            like.Comment = null;
            like.CreationDate = DateTime.UtcNow;
            like.Post = _postRepository.GetPostById(postId);
            like.User = _userRepository.GetUserById(userId);
            return like;
        }
    }
}