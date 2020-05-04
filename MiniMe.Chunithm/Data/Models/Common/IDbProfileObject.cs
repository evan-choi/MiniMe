using System;

namespace MiniMe.Chunithm.Data.Models
{
    public interface IDbProfileObject : IDbObject
    {
        Guid ProfileId { get; set; }
        
        UserProfile Profile { get; set; }
    }
}
