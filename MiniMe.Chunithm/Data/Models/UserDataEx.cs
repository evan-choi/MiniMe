using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserDataEx : Protocols.UserDataEx
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
