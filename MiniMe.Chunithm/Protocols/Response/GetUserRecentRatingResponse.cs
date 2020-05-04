namespace MiniMe.Chunithm.Protocols
{
    public class GetUserRecentRatingResponse
    {
        public int UserId { get; set; }

        public int Length { get; set; }

        public UserRecentRating[] UserRecentRatingList { get; set; }
    }
}
