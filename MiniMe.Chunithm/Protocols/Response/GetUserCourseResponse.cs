namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserCourseResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public int NextIndex { get; set; }

        public UserCourse[] UserCourseList { get; set; }
    }
}
