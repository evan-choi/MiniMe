using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserItem
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int ItemKind { get; set; }

        public int ItemId { get; set; }

        public int Stock { get; set; }

        public bool IsValid { get; set; }
    }
}
