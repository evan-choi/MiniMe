namespace MiniMe.Chunithm.Protocols
{
    public class GetUserItemResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public long NextIndex { get; set; }

        public int ItemKind { get; set; }

        public UserItem[] UserItemList { get; set; }
    }
}
