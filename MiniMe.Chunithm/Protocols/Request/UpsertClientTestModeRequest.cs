namespace MiniMe.Chunithm.Protocols
{
    public class UpsertClientTestModeRequest
    {
        public Payload ClientTestMode { get; set; }

        public class Payload
        {
            public string PlaceId { get; set; }

            public string ClientId { get; set; }

            public string UpdateDate { get; set; }

            public string IsDelivery { get; set; }

            public string GroupId { get; set; }

            public string GroupRole { get; set; }

            public string ContinueMode { get; set; }

            public string SelectMusicTime { get; set; }

            public string AdvertiseVolume { get; set; }

            public string EventMode { get; set; }

            public string EventMusicNum { get; set; }
        }
    }
}
