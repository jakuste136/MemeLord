using MemeLord.Logic.Repository;
using MemeLord.DataObjects.Request;
using System;
using System.Net;
using System.Net.Http;

namespace MemeLord.Logic.Modules.Comments
{
    public interface IUpdateCommentModule
    {
        void DeleteComment(int id);
        HttpResponseMessage UpdateCommentRating(UpdateCommentRatingRequest request);
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

        public HttpResponseMessage UpdateCommentRating(UpdateCommentRatingRequest request)
        {
            var comment = _commentRepository.GetCommentById(request.CommentId);
            comment.Rating = request.Rating;
            _commentRepository.UpdateComment(comment);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}