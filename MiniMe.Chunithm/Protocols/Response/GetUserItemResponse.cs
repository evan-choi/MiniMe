namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserItemResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public int ItemKind { get; set; }

        public UserItem[] UserItemList { get; set; }
    }
}
