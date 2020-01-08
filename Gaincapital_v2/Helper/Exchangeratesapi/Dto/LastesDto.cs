using Newtonsoft.Json;
using System;

namespace Gaincapital_v2.Helper.Exchangeratesapi.Dto
{
    class LastesDto
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }
    }
}
