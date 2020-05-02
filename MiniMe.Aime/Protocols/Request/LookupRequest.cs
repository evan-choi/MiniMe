namespace MiniMe.Aime.Protocols
{
    internal sealed class LookupRequest : AimeRequest
    {
        public string AccessCode { get; set; }
    }
}
