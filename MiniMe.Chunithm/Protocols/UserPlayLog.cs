using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UserPlayLog
    {
        public virtual int OrderId { get; set; }

        public virtual int Sortint { get; set; }

        public virtual int PlaceId { get; set; }

        public virtual DateTimeOffset PlayDate { get; set; }

        public virtual DateTimeOffset UserPlayDate { get; set; }

        public virtual int MusicId { get; set; }

        public virtual int Level { get; set; }

        public virtual int CustomId { get; set; }

        public virtual int PlayedUserId1 { get; set; }

        public virtual int PlayedUserId2 { get; set; }

        public virtual int PlayedUserId3 { get; set; }

        public virtual string PlayedUserName1 { get; set; }

        public virtual string PlayedUserName2 { get; set; }

        public virtual string PlayedUserName3 { get; set; }

        public virtual int PlayedMusicLevel1 { get; set; }

        public virtual int PlayedMusicLevel2 { get; set; }

        public virtual int PlayedMusicLevel3 { get; set; }

        public virtual int PlayedCustom1 { get; set; }

        public virtual int PlayedCustom2 { get; set; }

        public virtual int PlayedCustom3 { get; set; }

        public virtual int Track { get; set; }

        public virtual int Score { get; set; }

        public virtual int Rank { get; set; }

        public virtual int MaxCombo { get; set; }

        public virtual int MaxChain { get; set; }

        public virtual int RateTap { get; set; }

        public virtual int RateHold { get; set; }

        public virtual int RateSlide { get; set; }

        public virtual int RateAir { get; set; }

        public virtual int RateFlick { get; set; }

        public virtual int JudgeGuilty { get; set; }

        public virtual int JudgeAttack { get; set; }

        public virtual int JudgeJustice { get; set; }

        public virtual int JudgeCritical { get; set; }

        public virtual int EventId { get; set; }

        public virtual int PlayerRating { get; set; }

        public virtual bool IsNewRecord { get; set; }

        public virtual bool IsFullCombo { get; set; }

        public virtual int FullChainKind { get; set; }

        public virtual bool IsAllJustice { get; set; }

        public virtual bool IsContinue { get; set; }

        public virtual bool IsFreeToPlay { get; set; }

        public virtual int CharacterId { get; set; }

        public virtual int SkillId { get; set; }

        public virtual int PlayKind { get; set; }

        public virtual bool IsClear { get; set; }

        public virtual int SkillLevel { get; set; }

        public virtual int SkillEffect { get; set; }

        public virtual string PlaceName { get; set; }

        public virtual bool IsMaimai { get; set; }
    }
}
