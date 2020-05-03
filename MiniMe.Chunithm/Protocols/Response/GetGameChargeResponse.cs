namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetGameChargeResponse
    {
        public int Length { get; set; }

        public GameChargeItem[] GameChargeList { get; set; }
    }
}
