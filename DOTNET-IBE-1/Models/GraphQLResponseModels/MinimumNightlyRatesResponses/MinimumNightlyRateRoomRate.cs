using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse
{
    public class MinimumNightlyRateRoomRate
    {
        [JsonProperty("room_rate")]
        public MinimumNightlyRateRoomRateData RoomRate { get; set; }
    }
}
