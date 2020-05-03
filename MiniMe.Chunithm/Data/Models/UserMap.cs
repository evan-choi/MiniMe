using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserMap
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public int MapId { get; set; }

        public int Position { get; set; }

        public bool IsClear { get; set; }

        public int AreaId { get; set; }

        public int Routeint { get; set; }

        public int EventId { get; set; }

        public int Rate { get; set; }

        public int StatusCount { get; set; }

        public bool IsValid { get; set; }
    }
}
