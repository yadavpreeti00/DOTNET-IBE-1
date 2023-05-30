using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse
{
    public class MinimumNightlyRateRoomType
    {
        [JsonProperty("room_rates")]
        public List<MinimumNightlyRateRoomRate> RoomRates { get; set; }

        [JsonProperty("property_id")]
        public int PropertyId { get; set; }
    }
}
