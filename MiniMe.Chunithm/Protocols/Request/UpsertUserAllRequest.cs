namespace MiniMe.Chunithm.Protocols
{
    public class UpsertUserAllRequest
    {
        public string UserId { get; set; }

        public Payload UpsertUserAll { get; set; }

        public class Payload
        {
            public UserData[] UserData { get; set; }

            public UserGameOption[] UserGameOption { get; set; }

            public UserGameOptionEx[] UserGameOptionEx { get; set; }

            public UserMap[] UserMapList { get; set; }

            public UserCharacter[] UserCharacterList { get; set; }

            public UserItem[] UserItemList { get; set; }

            public UserMusic[] UserMusicDetailList { get; set; }

            public UserActivity[] UserActivityList { get; set; }

            public UserRecentRating[] UserRecentRatingList { get; set; }

            public UserPlayLog[] UserPlayLogList { get; set; }

            public UserCourse[] UserCourseList { get; set; }

            public UserDataEx[] UserDataEx { get; set; }

            public UserDuelList[] UserDuelList { get; set; }

            public string IsNewMapList { get; set; }

            public string IsNewCharacterList { get; set; }

            public string IsNewMusicDetailList { get; set; }

            public string IsNewItemList { get; set; }

            public string IsNewCourseList { get; set; }

            public string IsNewDuelList { get; set; }
        }
    }
}
