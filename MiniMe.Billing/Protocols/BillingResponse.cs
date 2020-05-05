using Newtonsoft.Json;

namespace MiniMe.Billing.Protocols
{
    public sealed class BillingResponse
    {
        // 0 or 6 is success, anything else is an error
        [JsonProperty("result")]
        public int Result { get; set; }

        // ???
        [JsonProperty("waittime")]
        public int WaitTime { get; set; }

        // Some sort of bandwidth-limiting thing..?
        // "line" refers to the shop's internet connection
        [JsonProperty("linelimit")]
        public int LineLimit { get; set; }

        // Server error message, copied to ALLNet debug log
        [JsonProperty("message")]
        public string Message { get; set; }

        // Keychip odometer limit. Game will lock out if the odometer reaches
        [JsonProperty("playlimit")]
        public int PlayLimit { get; set; }

        // RSA-SHA1 signature for new odometer limit.
        [JsonProperty("playlimitsig")]
        public string PlayLimitSignature { get; set; }

        // idk
        [JsonProperty("protocolver")]
        public string ProtocolVersion { get; set; }

        // A compound of two values. High 16 bits is the billing mode, low 16 bits
        // is the actual "nearfull" value. Not sure exactly what nearfull is, at a
        // guess it causes the client to check-in with the billing server when the
        // odometer is fewer than this many ticks away from its current limit.
        [JsonProperty("nearfull")]
        public int NearFull { get; set; }

        // RSA-SHA1 signature for the 32-bit nearfull value.
        [JsonProperty("nearfullsig")]
        public string NearFullSignature { get; set; }

        // ???
        [JsonProperty("fixlogcnt")]
        public int FixLogCount { get; set; }

        // ???
        [JsonProperty("fixinterval")]
        public int FixInterval { get; set; }

        // Monthly play count summary, visible in operator menu. The value below
        // is for a virgin machine fresh from the factory. Another example might be
        //
        // 201809/123:201810/456:201811/789
        //
        // which means
        //
        // Month 2018/09: 123 total plays
        // Month 2018/10: 456 total plays
        // Month 2018/11: 789 total plays
        [JsonProperty("playhistory")]
        public string PlayHistory { get; set; }
    }
}
