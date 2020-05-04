namespace MiniMe.Chunithm.Protocols
{
    public class GetUserCourseRequest : ILimitedPagination
    {
        public int UserId { get; set; }

        public int NextIndex { get; set; }

        public int MaxCount { get; set; }
    }
}
