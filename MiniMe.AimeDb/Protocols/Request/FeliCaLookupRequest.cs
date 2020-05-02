namespace MiniMe.AimeDb.Protocols
{
    internal sealed class FeliCaLookupRequest : AimeRequest
    {
        public string Idm { get; set; }

        public string Pmm { get; set; }
    }
}
