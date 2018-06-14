namespace MemeLord.DataObjects.Request
{ 
    public class UpdateCommentRatingRequest
    {
        public int CommentId { get; set; }
        public int Rating { get; set; }
    }
}