using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses
{
    public class RoomRate
    {
        [JsonProperty("room_rate")]
        public RoomRateData RoomRateData { get; set; }

        public RoomRate(RoomRateData roomRate)
        {
            this.RoomRateData = roomRate;
        }
    }
}
