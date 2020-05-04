using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GameEvent
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
