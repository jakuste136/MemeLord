namespace MemeLord.DataObjects.Request
{
    public class GetPostCommentsRequest
    {
        public int PostId { get; set; }
        public int LastId { get; set; }
        public int Count { get; set; }
    }
}