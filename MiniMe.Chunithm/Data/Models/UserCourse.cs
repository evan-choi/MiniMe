using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserCourse
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int CourseId { get; set; }

        public int ClassId { get; set; }

        public int PlayCount { get; set; }

        public int ScoreMax { get; set; }

        public bool IsFullCombo { get; set; }

        public bool IsAllJustice { get; set; }

        public bool IsSuccess { get; set; }

        public int ScoreRank { get; set; }

        public int EventId { get; set; }

        public DateTimeOffset LastPlayDate { get; set; }

        public int Param1 { get; set; }

        public int Param2 { get; set; }

        public int Param3 { get; set; }

        public int Param4 { get; set; }

        public bool IsClear { get; set; }
    }
}
