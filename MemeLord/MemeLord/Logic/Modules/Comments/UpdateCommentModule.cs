using MemeLord.Logic.Repository;
using System;

namespace MemeLord.Logic.Modules.Comments
{
    public interface IUpdateCommentModule
    {
        void DeleteComment(int id);
    }

    public class UpdateCommentModule : IUpdateCommentModule
    {
        ICommentRepository _commentRepository;

        public UpdateCommentModule(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void DeleteComment(int id)
        {
            var comment = _commentRepository.GetCommentById(id);
            comment.DeletionDate = DateTime.Now;
            _commentRepository.UpdateComment(comment);
        }
    }
}