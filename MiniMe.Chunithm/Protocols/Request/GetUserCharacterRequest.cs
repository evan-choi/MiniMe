namespace MiniMe.Chunithm.Protocols
{
    public class GetUserCharacterRequest : ILimitedPagination
    {
        public int UserId { get; set; }

        public int NextIndex { get; set; }

        public int MaxCount { get; set; }
    }
}
