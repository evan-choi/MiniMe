namespace MiniMe.Chunithm.Protocols
{
    public class GetUserDataResponse
    {
        public int UserId { get; set; }

        public UserProfile UserData { get; set; }
    }
}
