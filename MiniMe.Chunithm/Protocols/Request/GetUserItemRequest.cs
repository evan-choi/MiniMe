namespace MiniMe.Chunithm.Protocols
{
    public class GetUserItemRequest 
    {
        public int UserId { get; set; }

        public long NextIndex { get; set; }

        public int MaxCount { get; set; }
    }
}
