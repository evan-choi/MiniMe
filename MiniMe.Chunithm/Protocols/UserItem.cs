namespace MiniMe.Chunithm.Protocols
{
    public class UserItem
    {
        public virtual int ItemKind { get; set; }

        public virtual int ItemId { get; set; }

        public virtual int Stock { get; set; }

        public virtual bool IsValid { get; set; }
    }
}
