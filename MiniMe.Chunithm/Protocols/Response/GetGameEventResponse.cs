namespace MiniMe.Chunithm.Protocols
{
    public class GetGameEventResponse
    {
        public int Type { get; set; }

        public int Length { get; set; }

        public GameEvent[] GameEventList { get; set; }
    }
}
