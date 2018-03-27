using System.Collections.Generic;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;

namespace MemeLord.Logic.Mapping
{
    public interface ICommentMapper
    {
        IList<CommentDto> Map(IList<Comment> commentList);
    }

    public class CommentMapper : ICommentMapper
    {
        public IList<CommentDto> Map(IList<Comment> commentList)
        {
            var commentDtoList = new List<CommentDto>();

            foreach (var comment in commentList)
            {
                if (comment.MasterComment == null)
                {
                    //creating list of answers for this comment *** comments are already sorted by the date
                    var FollowingComments = new List<CommentDto>();
                    foreach (var tmp_comm in commentList)
                    {
                        if (tmp_comm.MasterComment.Id == comment.Id)
                            FollowingComments.Add(new CommentDto
                            {
                                Username = tmp_comm.User.Username,
                                Rating = tmp_comm.Rating,
                                Answers = null,
                                CreationDate = tmp_comm.CreationDate,
                                Description = tmp_comm.Description,
                                Id = tmp_comm.Id
                            });
                    }
                    //add mastercomment with its list
                    commentDtoList.Add(new CommentDto
                    {
                        Username = comment.User.Username,
                        Rating = comment.Rating,
                        Answers = FollowingComments,
                        CreationDate = comment.CreationDate,
                        Description = comment.Description,
                        Id = comment.Id
                    });
                } 
            }

            return commentDtoList;
        }
    }
}