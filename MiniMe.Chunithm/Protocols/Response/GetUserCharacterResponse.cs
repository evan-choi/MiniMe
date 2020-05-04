namespace MiniMe.Chunithm.Protocols
{
    public class GetUserCharacterResponse : IPagination
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserCharacter[] UserCharacterList { get; set; }
    }
}
