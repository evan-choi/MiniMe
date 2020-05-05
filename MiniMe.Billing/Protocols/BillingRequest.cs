using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MiniMe.Billing.Protocols
{
    public sealed class BillingRequest : Collection<IReadOnlyDictionary<string, string>>
    {
        [JsonIgnore]
        public string KeyChipId => this[0]["keychipid"];
    }
}
