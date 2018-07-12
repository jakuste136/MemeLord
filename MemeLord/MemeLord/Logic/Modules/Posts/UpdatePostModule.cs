using MemeLord.Logic.Repository;
using System;

namespace MemeLord.Logic.Modules.Posts
{
    public interface IUpdatePostModule
    {
        void DeletePost(int id);
    }

    public class UpdatePostModule : IUpdatePostModule
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostModule(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetPostById(id);
            post.DeletionDate = DateTime.Now;
            _postRepository.UpdatePost(post);
        }
    }
}