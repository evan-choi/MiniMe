using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserDuelList
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int DuelId { get; set; }

        public int Progress { get; set; }

        public int Point { get; set; }

        public bool IsClear { get; set; }

        public DateTimeOffset LastPlayDate { get; set; }

        public int Param1 { get; set; }

        public int Param2 { get; set; }

        public int Param3 { get; set; }

        public int Param4 { get; set; }
    }
}
