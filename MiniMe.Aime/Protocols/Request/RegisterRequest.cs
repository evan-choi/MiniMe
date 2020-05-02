namespace MiniMe.Aime.Protocols
{
    internal sealed class RegisterRequest : AimeRequest
    {
        public string AccessCode { get; set; }
    }
}
