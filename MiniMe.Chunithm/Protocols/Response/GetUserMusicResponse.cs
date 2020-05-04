namespace MiniMe.Chunithm.Protocols
{
    public class GetUserMusicResponse : IPagination
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserMusic[] UserMusicList { get; set; }
    }
}
