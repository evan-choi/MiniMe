using System;
using System.ComponentModel.DataAnnotations;

namespace MiniMe.Chunithm.Data.Models
{
    public class UserDataExt
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string CompatibleCmVersion { get; set; }

        public int Medal { get; set; }

        public int MapIconId { get; set; }

        public int VoiceId { get; set; }

        public int Ext1 { get; set; }

        public int Ext2 { get; set; }

        public int Ext3 { get; set; }

        public int Ext4 { get; set; }

        public int Ext5 { get; set; }

        public int Ext6 { get; set; }

        public int Ext7 { get; set; }

        public int Ext8 { get; set; }

        public int Ext9 { get; set; }

        public int Ext10 { get; set; }

        public int Ext11 { get; set; }

        public int Ext12 { get; set; }

        public int Ext13 { get; set; }

        public int Ext14 { get; set; }

        public int Ext15 { get; set; }

        public int Ext16 { get; set; }

        public int Ext17 { get; set; }

        public int Ext18 { get; set; }

        public int Ext19 { get; set; }

        public int Ext20 { get; set; }

        public string ExtStr1 { get; set; }

        public string ExtStr2 { get; set; }

        public string ExtStr3 { get; set; }

        public string ExtStr4 { get; set; }

        public string ExtStr5 { get; set; }

        public long ExtLong1 { get; set; }

        public long ExtLong2 { get; set; }

        public long ExtLong3 { get; set; }

        public long ExtLong4 { get; set; }

        public long ExtLong5 { get; set; }
    }
}
