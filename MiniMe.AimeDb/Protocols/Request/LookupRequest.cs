namespace MiniMe.AimeDb.Protocols
{
    internal sealed class LookupRequest : AimeRequest
    {
        public string Luid { get; set; }
    }
}
