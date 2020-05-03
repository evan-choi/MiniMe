using System;

namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetUserPreviewResponse
    {
        public string UserId { get; set; }

        public bool IsLogin { get; set; }

        /// <summary>
        /// yyyy-MM-dd hh:mm:ss
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        #region UserData
        public string UserName { get; set; }

        public string ReincarnationNum { get; set; }

        public string Level { get; set; }

        public string Exp { get; set; }

        public string PlayerRating { get; set; }

        public string LastGameId { get; set; }

        public string LastRomVersion { get; set; }

        public string LastDataVersion { get; set; }

        public string LastPlayDate { get; set; }

        public string TrophyId { get; set; }
        #endregion

        #region Selected UserCharacter
        public UserCharacter UserCharacter { get; set; }
        #endregion

        #region UserGameOption
        public string PlayerLevel { get; set; }

        public string Rating { get; set; }

        public string Headphone { get; set; }
        #endregion
    }
}
