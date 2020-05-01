using System;
using Newtonsoft.Json;

namespace MiniMe.AllNet.Protocols
{
    public class PowerOnRequest
    {
        [JsonProperty("game_id")]
        public string GameId { get; set; }

        [JsonProperty("ver")]
        public Version Version { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("firm_ver")]
        public string FirmVersion { get; set; }

        [JsonProperty("boot_ver")]
        public string BootVersion { get; set; }

        [JsonProperty("encode")]
        public string Encode { get; set; }

        [JsonProperty("format_ver")]
        public string FormatVersion { get; set; }

        [JsonProperty("hops")]
        public string Hops { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
