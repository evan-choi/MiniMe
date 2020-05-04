namespace MiniMe.Chunithm.Protocols
{
    public interface ILimitedPagination : IPagination
    {
        int MaxCount { get; set; }
    }
}
