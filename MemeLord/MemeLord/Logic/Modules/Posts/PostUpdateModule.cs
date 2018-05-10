using MemeLord.DataObjects.Request;
using MemeLord.Logic.Repository;
using System.Net;
using System.Net.Http;

namespace MemeLord.Logic.Modules.Posts
{
    public interface IPostUpdateModule
    {
        HttpResponseMessage UpdatePostRating(UpdatePostRatingRequest request);
    }

    public class PostUpdateModule : IPostUpdateModule
    {

        private readonly IPostRepository _postRepository;

        public PostUpdateModule(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public HttpResponseMessage UpdatePostRating(UpdatePostRatingRequest request)
        {
            var post = _postRepository.GetPostById(request.PostId);
            post.Rating = request.Rating;
            _postRepository.UpdatePost(post);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}