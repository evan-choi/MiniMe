using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GameEvent
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}
