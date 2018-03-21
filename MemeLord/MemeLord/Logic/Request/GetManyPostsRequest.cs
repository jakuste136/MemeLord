namespace MemeLord.Logic.Request
{
    public class GetManyPostsRequest
    {
        public int LastId { get; set; }
        public int Count { get; set; }
    }
}