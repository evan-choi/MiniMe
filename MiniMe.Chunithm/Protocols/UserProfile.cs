using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UserProfile
    {
        // NFC LUID
        public virtual string AccessCode { get; set; }

        // Uses wide latin chars
        public virtual string UserName { get; set; }

        public virtual bool IsWebJoin { get; set; }

        public virtual DateTimeOffset WebLimitDate { get; set; }

        public virtual int Level { get; set; }

        public virtual int ReincarnationNum { get; set; }

        public virtual int Exp { get; set; }

        public virtual int Point { get; set; }

        public virtual long TotalPoint { get; set; }

        public virtual int PlayCount { get; set; }

        public virtual int MultiPlayCount { get; set; }

        public virtual int MultiWinCount { get; set; }

        public virtual int RequestResCount { get; set; }

        public virtual int AcceptResCount { get; set; }

        public virtual int SuccessResCount { get; set; }

        public virtual int PlayerRating { get; set; }

        public virtual int HighestRating { get; set; }

        public virtual int NameplateId { get; set; }

        public virtual int FrameId { get; set; }

        public virtual int CharacterId { get; set; }

        public virtual int TrophyId { get; set; }

        public virtual int PlayedTutorialBit { get; set; }

        public virtual int FirstTutorialCancelNum { get; set; }

        public virtual int MasterTutorialCancelNum { get; set; }

        public virtual int TotalRepertoireCount { get; set; }

        public virtual int TotalMapNum { get; set; }

        public virtual long TotalHiScore { get; set; }

        public virtual long TotalBasicHighScore { get; set; }

        public virtual long TotalAdvancedHighScore { get; set; }

        public virtual long TotalExpertHighScore { get; set; }

        public virtual long TotalMasterHighScore { get; set; }

        public virtual DateTimeOffset EventWatchedDate { get; set; }

        public virtual int FriendCount { get; set; }

        public virtual bool IsMaimai { get; set; }

        public virtual string FirstGameId { get; set; }

        public virtual string FirstRomVersion { get; set; }

        public virtual string FirstDataVersion { get; set; }

        public virtual DateTimeOffset FirstPlayDate { get; set; }

        public virtual string LastGameId { get; set; }

        public virtual string LastRomVersion { get; set; }

        public virtual string LastDataVersion { get; set; }

        public virtual DateTimeOffset LastPlayDate { get; set; }

        // ALLNet place ID
        public virtual int LastPlaceId { get; set; }

        // ALLNet place name
        public virtual string LastPlaceName { get; set; }

        // ALLNet "region0"
        public virtual string LastRegionId { get; set; }

        // ALLNet "region_name0"
        public virtual string LastRegionName { get; set; }

        // ALLNet "allnet_id"
        public virtual string LastAllNetId { get; set; }

        // Keychip ID
        public virtual string LastClientId { get; set; }
    }
}
