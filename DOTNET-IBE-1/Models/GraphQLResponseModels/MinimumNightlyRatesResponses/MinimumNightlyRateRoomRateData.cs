using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse
{
    public class MinimumNightlyRateRoomRateData
    {
        [JsonProperty("basic_nightly_rate")]
        public double BasicNightlyRate { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
