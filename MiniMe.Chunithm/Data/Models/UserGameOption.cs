using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserGameOption
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public int BgInfo { get; set; }

        public int FieldColor { get; set; }

        public int GuideSound { get; set; }

        public int SoundEffect { get; set; }

        public int GuideLine { get; set; }

        public int Speed { get; set; }

        public int OptionSet { get; set; }

        public int Matching { get; set; }

        public int JudgePos { get; set; }

        public int Rating { get; set; }

        public int JudgeJustice { get; set; }

        public int JudgeAttack { get; set; }

        public int Headphone { get; set; }

        public int PlayerLevel { get; set; }

        public int SuccessTap { get; set; }

        public int SuccessExTap { get; set; }

        public int SuccessSlideHold { get; set; }

        public int SuccessAir { get; set; }

        public int SuccessFlick { get; set; }

        public int SuccessSkill { get; set; }

        public int SuccessTapTimbre { get; set; }

        public int Privacy { get; set; }
    }
}
