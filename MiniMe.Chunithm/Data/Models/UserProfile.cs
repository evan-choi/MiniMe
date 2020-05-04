using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserProfile : Protocols.UserProfile, IDbObject
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public Guid AimeId { get; set; }

        public UserDataEx DataEx { get; set; }

        public UserGameOption GameOption { get; set; }

        public UserGameOptionEx GameOptionEx { get; set; }

        public IList<UserActivity> Activities { get; set; }

        public IList<UserCharacter> Characters { get; set; }

        public IList<UserCourse> Courses { get; set; }

        public IList<UserDuelList> DuelLists { get; set; }

        public IList<UserItem> Items { get; set; }

        public IList<UserMap> Maps { get; set; }

        public IList<UserMusic> Musics { get; set; }

        public IList<UserPlayLog> PlayLogs { get; set; }
    }
}
