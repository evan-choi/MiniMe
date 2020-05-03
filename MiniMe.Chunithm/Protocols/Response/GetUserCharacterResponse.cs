namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserCharacterResponse
    {
        public string UserID { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserCharacter[] UserCharacterList { get; set; }
    }
}
