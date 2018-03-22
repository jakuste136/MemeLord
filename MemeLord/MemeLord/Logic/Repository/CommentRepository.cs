using MemeLord.Logic.Database;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Request;
using MemeLord.Logic.Response;
using MemeLord.Models;
using System.Collections.Generic;
using MemeLord.Logic.Queries;
using System.Linq;

namespace MemeLord.Logic.Repository
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        GetPostCommentsResponse GetManyComments(GetPostCommentsRequest request);
    }

    public class CommentRepository : ICommentRepository
    {
        public Comment GetCommentById(int id)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var data = db.Query<Comment>()
                    .Include(c => c.MasterComment)
                    .SingleOrDefault(c => c.Id == id);

                return data;
            }
        }

        public GetPostCommentsResponse GetManyComments(GetPostCommentsRequest request)
        {
            using (var db = CustomDatabaseFactory.GetConnection())
            {
                var queryResult =  db.Query<Comment>().OrderByDescending(c => c.CreationDate).
                    Where(c => c.Post.Id == request.PostId).ToEnumerable();

                return MapEntityToDto(queryResult);
            }

        }

        private GetPostCommentsResponse MapEntityToDto(IEnumerable<Comment> commentList)
        {
            var commentDtoList = new List<CommentDto>();

            foreach (var comment in commentList)
            {
                if (comment.MasterComment == null)
                {
                    //creating list of answers for this comment *** comments are already sorted by the date
                    var FollowingComments = new List<CommentDto>();
                    foreach(var tmp_comm in commentList)
                    {
                        if (tmp_comm.MasterComment.Id == comment.Id)
                            FollowingComments.Add(new CommentDto
                            {
                                Author = tmp_comm.User.Username,
                                Rating = tmp_comm.Rating,
                                Answers = null,
                                CreationDate = tmp_comm.CreationDate,
                                DeletionDate = tmp_comm.DeletionDate,
                                Description = tmp_comm.Description
                            });
                    }


                    commentDtoList.Add(new CommentDto
                    {
                        Author = comment.User.Username,
                        Rating = comment.Rating,
                        Answers = FollowingComments,
                        CreationDate = comment.CreationDate,
                        DeletionDate = comment.DeletionDate,
                        Description = comment.Description
                    });
                }
            }

            return new GetPostCommentsResponse
            {
                Number = commentDtoList.Count,
                CommentsList = commentDtoList
            };

        }

        
    }
}