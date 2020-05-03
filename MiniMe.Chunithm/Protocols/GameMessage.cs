using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GameMessage
    {
        public int Type { get; set; }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}
