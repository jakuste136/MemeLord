namespace MemeLord.DataObjects.Request
{
    public class UpdatePostRatingRequest
    {
        public int PostId { get; set; }
        public int Rating { get; set; }
    }
}