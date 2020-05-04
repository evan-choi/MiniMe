namespace MiniMe.Chunithm.Protocols
{
    public class GetUserRegionResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public UserRegion[] UserRegionList { get; set; }
    }
}
