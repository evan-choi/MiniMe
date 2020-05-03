namespace MiniMe.Chunithm.Protocols.Response
{
    public class GetGameSettingResponse
    {
        public Setting GameSetting { get; set; }

        public bool IsDumpUpload { get; set; }

        public bool IsAou { get; set; }

        public class Setting
        {
            public string DataVersion { get; set; }

            public string IsMaintenance { get; set; }

            public string RequestInterval { get; set; }

            public string RebootStartTime { get; set; }

            public string RebootEndTime { get; set; }

            public string IsBackgroundDistribute { get; set; }

            public string MaxCountCharacter { get; set; }

            public string MaxCountItem { get; set; }

            public string MaxCountMusic { get; set; }
        }
    }
}
