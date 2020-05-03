namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetGameSaleResponse
    {
        public int Type { get; set; }

        public int Length { get; set; }
        
        public GameSale[] GameSaleList { get; set; }
    }
}
