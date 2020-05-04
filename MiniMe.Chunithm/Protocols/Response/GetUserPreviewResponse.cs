using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GetUserPreviewResponse
    {
        public int UserId { get; set; }

        public bool IsLogin { get; set; }

        /// <summary>
        /// yyyy-MM-dd hh:mm:ss
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        #region UserData
        public string UserName { get; set; }

        public int ReincarnationNum { get; set; }

        public int Level { get; set; }

        public int Exp { get; set; }

        public int PlayerRating { get; set; }

        public string LastGameId { get; set; }

        public string LastRomVersion { get; set; }

        public string LastDataVersion { get; set; }

        public DateTime LastPlayDate { get; set; }

        public int TrophyId { get; set; }
        #endregion

        #region Selected UserCharacter
        public UserCharacter UserCharacter { get; set; }
        #endregion

        #region UserGameOption
        public int PlayerLevel { get; set; }

        public int Rating { get; set; }

        public int Headphone { get; set; }
        #endregion
    }
}
