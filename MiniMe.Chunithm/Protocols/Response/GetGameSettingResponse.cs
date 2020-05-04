using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GetGameSettingResponse
    {
        public Payload GameSetting { get; set; }

        public bool IsDumpUpload { get; set; }

        public bool IsAou { get; set; }

        public class Payload
        {
            public string DataVersion { get; set; }

            public bool IsMaintenance { get; set; }

            public int RequestInterval { get; set; }

            public DateTime RebootStartTime { get; set; }

            public DateTime RebootEndTime { get; set; }

            public bool IsBackgroundDistribute { get; set; }

            public int MaxCountCharacter { get; set; }

            public int MaxCountItem { get; set; }

            public int MaxCountMusic { get; set; }
        }
    }
}
