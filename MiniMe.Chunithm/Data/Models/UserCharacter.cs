using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserCharacter
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int CharacterId { get; set; }

        public int PlayCount { get; set; }

        public int Level { get; set; }

        public int SkillId { get; set; }

        public int FriendshipExp { get; set; }

        public bool IsValid { get; set; }

        public bool IsNewMark { get; set; }

        public int Param1 { get; set; }

        public int Param2 { get; set; }
    }
}
