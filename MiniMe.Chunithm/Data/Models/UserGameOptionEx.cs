using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserGameOptionEx : Protocols.UserGameOptionEx
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
