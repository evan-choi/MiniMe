using System;

namespace MiniMe.Chunithm.Protocols
{
    public class UpsertClientSettingRequest
    {
        public Payload ClientSetting { get; set; }

        public class Payload
        {
            public string PlaceId { get; set; }

            public string ClientId { get; set; }

            public string PlaceName { get; set; }

            public string RegionId { get; set; }

            public string RegionName { get; set; }

            public string BordId { get; set; }

            public Version RomVersion { get; set; }

            public Version DataVersion { get; set; }

            public int DumpFileNum { get; set; }
        }
    }
}
