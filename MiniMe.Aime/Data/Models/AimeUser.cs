﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Aime.Data.Models
{
    public sealed class AimeUser
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public string AccessCode { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset AccessAt { get; set; }
    }
}
