using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserPaylog
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int OrderId { get; set; }

        public int Sortint { get; set; }

        public int PlaceId { get; set; }

        public DateTimeOffset PlayDate { get; set; }

        public DateTimeOffset UserPlayDate { get; set; }

        public int MusicId { get; set; }

        public int Level { get; set; }

        public int CustomId { get; set; }

        public int PlayedUserId1 { get; set; }

        public int PlayedUserId2 { get; set; }

        public int PlayedUserId3 { get; set; }

        public string PlayedUserName1 { get; set; }

        public string PlayedUserName2 { get; set; }

        public string PlayedUserName3 { get; set; }

        public int PlayedMusicLevel1 { get; set; }

        public int PlayedMusicLevel2 { get; set; }

        public int PlayedMusicLevel3 { get; set; }

        public int PlayedCustom1 { get; set; }

        public int PlayedCustom2 { get; set; }

        public int PlayedCustom3 { get; set; }

        public int Track { get; set; }

        public int Score { get; set; }

        public int Rank { get; set; }

        public int MaxCombo { get; set; }

        public int MaxChain { get; set; }

        public int RateTap { get; set; }

        public int RateHold { get; set; }

        public int RateSlide { get; set; }

        public int RateAir { get; set; }

        public int RateFlick { get; set; }

        public int JudgeGuilty { get; set; }

        public int JudgeAttack { get; set; }

        public int JudgeJustice { get; set; }

        public int JudgeCritical { get; set; }

        public int EventId { get; set; }

        public int PlayerRating { get; set; }

        public bool IsNewRecord { get; set; }

        public bool IsFullCombo { get; set; }

        public int FullChainKind { get; set; }

        public bool IsAllJustice { get; set; }

        public bool IsContinue { get; set; }

        public bool IsFreeToPlay { get; set; }

        public int CharacterId { get; set; }

        public int SkillId { get; set; }

        public int PlayKind { get; set; }

        public bool IsClear { get; set; }

        public int SkillLevel { get; set; }

        public int SkillEffect { get; set; }

        public string PlaceName { get; set; }

        public bool IsMaimai { get; set; }
    }
}
