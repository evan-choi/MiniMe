using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserGameOptionEx : Protocols.UserGameOptionEx, IDbProfileObject
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        Guid IDbProfileObject.ProfileId
        {
            get => Id;
            set => Id = value;
        }

        public UserProfile Profile { get; set; }
    }
}
