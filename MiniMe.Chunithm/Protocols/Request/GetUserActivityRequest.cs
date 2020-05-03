namespace MiniMe.Chunithm.Protocols
{
    public class GetUserActivityRequest
    {
        public string UserId { get; set; }
        
        public int Kind { get; set; }
    }
}
