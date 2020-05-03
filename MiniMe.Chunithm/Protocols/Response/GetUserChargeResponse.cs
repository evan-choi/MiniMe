namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserChargeResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public object[] UserChargeList { get; set; }
    }
}
