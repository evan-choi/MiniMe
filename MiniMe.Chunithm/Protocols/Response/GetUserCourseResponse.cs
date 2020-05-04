namespace MiniMe.Chunithm.Protocols
{
    public class GetUserCourseResponse : IPagination
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserCourse[] UserCourseList { get; set; }
    }
}
