namespace MiniMe.Chunithm.Protocols
{
    public class GetGameIdlistResponse
    {
        public int Type { get; set; }

        public int Length { get; set; }

        public object[] GameIdlistList { get; set; }
    }
}
