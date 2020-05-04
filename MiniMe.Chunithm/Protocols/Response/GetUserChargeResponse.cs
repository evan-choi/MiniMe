namespace MiniMe.Chunithm.Protocols
{
    public class GetUserChargeResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public object[] UserChargeList { get; set; }
    }
}
