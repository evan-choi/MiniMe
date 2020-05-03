namespace MiniMe.Chunithm.Protocols
{
    public class UserMusic
    {
        public virtual int MusicId { get; set; }

        public virtual int Level { get; set; }

        public virtual int PlayCount { get; set; }

        public virtual int ScoreMax { get; set; }

        public virtual int ResRequestCount { get; set; }

        public virtual int ResAcceptCount { get; set; }

        public virtual int ResSuccessCount { get; set; }

        public virtual int MissCount { get; set; }

        public virtual int MaxComboCount { get; set; }

        public virtual bool IsFullCombo { get; set; }

        public virtual bool IsAllJustice { get; set; }

        public virtual bool IsSuccess { get; set; }

        public virtual int FullChain { get; set; }

        public virtual int MaxChain { get; set; }

        public virtual int ScoreRank { get; set; }

        public virtual bool IsLock { get; set; }
    }
}
