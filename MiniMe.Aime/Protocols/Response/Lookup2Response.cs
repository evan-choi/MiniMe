namespace MiniMe.Aime.Protocols
{
    internal sealed class Lookup2Response : AimeResponse
    {
        public int? AimeId { get; set; }

        public RegisterLevel RegisterLevel { get; set; }
    }
}
