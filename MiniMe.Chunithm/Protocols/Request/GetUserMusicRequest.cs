﻿namespace MiniMe.Chunithm.Protocols
{
    public class GetUserMusicRequest
    {
        public string UserId { get; set; }

        public int NextIndex { get; set; }

        public int MaxCount { get; set; }
    }
}