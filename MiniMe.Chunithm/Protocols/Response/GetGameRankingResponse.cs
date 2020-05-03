namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetGameRankingResponse
    {
        public int Type { get; set; }

        public GameRanking[] GameRankingList { get; set; }
    }
}
