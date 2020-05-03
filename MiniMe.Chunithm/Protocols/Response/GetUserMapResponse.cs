namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserMapResponse
    {
        public string UserId { get; set; }
        
        public int Length { get; set; }
        
        public UserMap[] UserMapList { get; set; }
    }
}
