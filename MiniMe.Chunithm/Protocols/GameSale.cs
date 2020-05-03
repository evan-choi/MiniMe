using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GameSale
    {
        public int OrderId { get; set; }

        public int Type { get; set; }

        public int Id { get; set; }

        public int Rate { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}
