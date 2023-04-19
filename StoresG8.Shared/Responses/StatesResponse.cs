
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresG8.Shared.Responses
{
    using Newtonsoft.Json;

    namespace Stores.Shared.Responses
    {
        public class StateResponse
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("iso2")]
            public string? Iso2 { get; set; }
        }
    }


}