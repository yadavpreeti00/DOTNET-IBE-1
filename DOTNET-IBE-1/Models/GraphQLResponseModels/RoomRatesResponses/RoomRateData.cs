using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses
{
    public class RoomRateData
    {
        [JsonProperty("basic_nightly_rate")]
        public double BasicNightlyRate { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }

        public RoomRateData(double basicNightlyRate, string date)
        {
            this.BasicNightlyRate = basicNightlyRate;
            this.Date = date;
        }
    }
}
