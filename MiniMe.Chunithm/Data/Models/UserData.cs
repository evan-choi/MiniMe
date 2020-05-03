using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserData
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid PlayerId { get; set; }

        // NFC LUID
        public string AccessCode { get; set; }

        // Uses wide latin chars
        public string UserName { get; set; }

        public bool IsWebJoin { get; set; }

        public DateTimeOffset WebLimitDate { get; set; }

        public int Level { get; set; }

        public int ReincarnationNum { get; set; }

        public int Exp { get; set; }

        public int Point { get; set; }

        public long TotalPoint { get; set; }

        public int PlayCount { get; set; }

        public int MultiPlayCount { get; set; }

        public int MultiWinCount { get; set; }

        public int RequestResCount { get; set; }

        public int AcceptResCount { get; set; }

        public int SuccessResCount { get; set; }

        public int PlayerRating { get; set; }

        public int HighestRating { get; set; }

        public int NameplateId { get; set; }

        public int FrameId { get; set; }

        public int CharacterId { get; set; }

        public int TrophyId { get; set; }

        public int PlayedTutorialBit { get; set; }

        public int FirstTutorialCancelNum { get; set; }

        public int MasterTutorialCancelNum { get; set; }

        public int TotalRepertoireCount { get; set; }

        public int TotalMapNum { get; set; }

        public long TotalHiScore { get; set; }

        public long TotalBasicHighScore { get; set; }

        public long TotalAdvancedHighScore { get; set; }

        public long TotalExpertHighScore { get; set; }

        public long TotalMasterHighScore { get; set; }

        public DateTimeOffset EventWatchedDate { get; set; }

        public int FriendCount { get; set; }

        public bool IsMaimai { get; set; }

        public string FirstGameId { get; set; }

        public string FirstRomVersion { get; set; }

        public string FirstDataVersion { get; set; }

        public DateTimeOffset FirstPlayDate { get; set; }

        public string LastGameId { get; set; }

        public string LastRomVersion { get; set; }

        public string LastDataVersion { get; set; }

        public DateTimeOffset LastPlayDate { get; set; }

        // ALLNet place ID
        public int LastPlaceId { get; set; }

        // ALLNet place name
        public string LastPlaceName { get; set; }

        // ALLNet "region0"
        public string LastRegionId { get; set; }

        // ALLNet "region_name0"
        public string LastRegionName { get; set; }

        // ALLNet "allnet_id"
        public string LastAllNetId { get; set; }

        // Keychip ID
        public string LastClientId { get; set; }
    }
}
