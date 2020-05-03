using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UserCourse
    {
        public virtual int CourseId { get; set; }

        public virtual int ClassId { get; set; }

        public virtual int PlayCount { get; set; }

        public virtual int ScoreMax { get; set; }

        public virtual bool IsFullCombo { get; set; }

        public virtual bool IsAllJustice { get; set; }

        public virtual bool IsSuccess { get; set; }

        public virtual int ScoreRank { get; set; }

        public virtual int EventId { get; set; }

        public virtual DateTimeOffset LastPlayDate { get; set; }

        public virtual int Param1 { get; set; }

        public virtual int Param2 { get; set; }

        public virtual int Param3 { get; set; }

        public virtual int Param4 { get; set; }

        public virtual bool IsClear { get; set; }
    }
}
