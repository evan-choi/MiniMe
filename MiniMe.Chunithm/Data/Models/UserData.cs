using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserData : Protocols.UserData
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid PlayerId { get; set; }
    }
}
