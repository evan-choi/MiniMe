using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserMusic
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int MusicId { get; set; }

        public int Level { get; set; }

        public int PlayCount { get; set; }

        public int ScoreMax { get; set; }

        public int ResRequestCount { get; set; }

        public int ResAcceptCount { get; set; }

        public int ResSuccessCount { get; set; }

        public int MissCount { get; set; }

        public int MaxComboCount { get; set; }

        public bool IsFullCombo { get; set; }

        public bool IsAllJustice { get; set; }

        public bool IsSuccess { get; set; }

        public int FullChain { get; set; }

        public int MaxChain { get; set; }

        public int ScoreRank { get; set; }

        public bool IsLock { get; set; }
    }
}
