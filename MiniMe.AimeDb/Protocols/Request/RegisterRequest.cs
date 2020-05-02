namespace MiniMe.AimeDb.Protocols
{
    internal sealed class RegisterRequest : AimeRequest
    {
        public string Luid { get; set; }
    }
}
