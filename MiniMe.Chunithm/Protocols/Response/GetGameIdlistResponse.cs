namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetGameIdlistResponse
    {
        public int Type { get; set; }

        public int Length { get; set; }

        public object[] GameIdlistList { get; set; }
    }
}
