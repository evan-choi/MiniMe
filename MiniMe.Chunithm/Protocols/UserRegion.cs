using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UserRegion
    {
        public int RegionId { get; set; }

        public int PlayCount { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}
