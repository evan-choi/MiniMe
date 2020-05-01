using Newtonsoft.Json;

namespace MiniMe.AllNet.Protocols
{
    public class PowerOnResponse
    {
        [JsonProperty("stat")]
        public int Stat { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("region0")]
        public string Region0 { get; set; }

        [JsonProperty("region_name0")]
        public string RegionName0 { get; set; }

        [JsonProperty("region_name1")]
        public string RegionName1 { get; set; }

        [JsonProperty("region_name2")]
        public string RegionName2 { get; set; }

        [JsonProperty("region_name3")]
        public string RegionName3 { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("allnet_id")]
        public string AllNetId { get; set; }

        [JsonProperty("client_timezone")]
        public string ClientTimezone { get; set; }

        [JsonProperty("utc_time")]
        public string UtcTime { get; set; }

        [JsonProperty("setting")]
        public string Setting { get; set; }

        [JsonProperty("res_ver")]
        public string ResVersion { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
