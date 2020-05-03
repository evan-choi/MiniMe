namespace MiniMe.Chunithm.Protocols
{
    public class GetUserDuelRequest
    {
        public string UserId { get; set; }

        public int DuelId { get; set; }

        public bool IsAllDuel { get; set; }
    }
}
