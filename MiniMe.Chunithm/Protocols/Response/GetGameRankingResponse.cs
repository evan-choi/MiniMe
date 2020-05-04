namespace MiniMe.Chunithm.Protocols
{
    public class GetGameRankingResponse
    {
        public int Type { get; set; }

        public GameRanking[] GameRankingList { get; set; }
    }
}
