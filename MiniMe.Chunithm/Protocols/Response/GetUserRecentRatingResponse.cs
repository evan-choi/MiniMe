namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserRecentRatingResponse
    {
        public string UserId { get; set; }

        public int Length { get; set; }

        public UserRecentRating[] UserRecentRatingList { get; set; }
    }
}
