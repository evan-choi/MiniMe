namespace MiniMe.Chunithm.Protocols
{
    public class UserCharacter
    {
        public virtual int CharacterId { get; set; }

        public virtual int PlayCount { get; set; }

        public virtual int Level { get; set; }

        public virtual int SkillId { get; set; }

        public virtual int FriendshipExp { get; set; }

        public virtual bool IsValid { get; set; }

        public virtual bool IsNewMark { get; set; }

        public virtual int Param1 { get; set; }

        public virtual int Param2 { get; set; }
    }
}
