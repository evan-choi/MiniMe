namespace MiniMe.Chunithm.Protocols
{
    public class GetUserDuelResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public UserDuelList[] UserDuelList { get; set; }
    }
}
