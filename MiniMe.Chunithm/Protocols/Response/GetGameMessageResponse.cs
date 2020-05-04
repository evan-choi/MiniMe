namespace MiniMe.Chunithm.Protocols
{
    public class GetGameMessageResponse
    {
        public int Type { get; set; }

        public int Length { get; set; }

        public GameMessage[] GameMessageList { get; set; }
    }
}
