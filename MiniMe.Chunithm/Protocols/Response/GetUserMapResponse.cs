namespace MiniMe.Chunithm.Protocols
{
    public class GetUserMapResponse
    {
        public int UserId { get; set; }
        
        public int Length { get; set; }
        
        public UserMap[] UserMapList { get; set; }
    }
}
