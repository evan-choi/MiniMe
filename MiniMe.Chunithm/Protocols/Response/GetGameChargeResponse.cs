namespace MiniMe.Chunithm.Protocols
{
    public class GetGameChargeResponse
    {
        public int Length { get; set; }

        public GameChargeItem[] GameChargeList { get; set; }
    }
}
