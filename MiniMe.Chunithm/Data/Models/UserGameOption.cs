using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserGameOption : Protocols.UserGameOption
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
