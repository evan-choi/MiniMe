namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserActivityResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public int Kind { get; set; }

        public UserActivity[] UserActivityList { get; set; }
    }
}
