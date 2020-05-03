using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UserDuelList
    {
        public virtual int DuelId { get; set; }

        public virtual int Progress { get; set; }

        public virtual int Point { get; set; }

        public virtual bool IsClear { get; set; }

        public virtual DateTimeOffset LastPlayDate { get; set; }

        public virtual int Param1 { get; set; }

        public virtual int Param2 { get; set; }

        public virtual int Param3 { get; set; }

        public virtual int Param4 { get; set; }
    }
}
