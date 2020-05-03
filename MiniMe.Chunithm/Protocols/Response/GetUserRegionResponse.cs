namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserRegionResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public UserRegion[] UserRegionList { get; set; }
    }
}
