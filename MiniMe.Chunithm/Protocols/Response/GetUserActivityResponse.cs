namespace MiniMe.Chunithm.Protocols
{
    public class GetUserActivityResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public int Kind { get; set; }

        public UserActivity[] UserActivityList { get; set; }
    }
}
