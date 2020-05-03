namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserMusicResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserMusic[] UserMusicList { get; set; }
    }
}
