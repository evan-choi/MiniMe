namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserDuelResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public UserDuelList[] UserDuelList { get; set; }
    }
}
