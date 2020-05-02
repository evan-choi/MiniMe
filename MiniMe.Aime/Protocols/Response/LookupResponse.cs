namespace MiniMe.Aime.Protocols
{
    internal sealed class LookupResponse : AimeResponse
    {
        public int? AimeId { get; set; }

        public RegisterLevel RegisterLevel { get; set; }
    }
}
