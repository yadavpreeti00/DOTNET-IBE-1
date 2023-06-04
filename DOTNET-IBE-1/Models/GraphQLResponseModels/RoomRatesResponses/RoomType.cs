using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses
{
    public class RoomType
    {
        [JsonProperty("room_type_name")]
        public string RoomTypeName { get; set; }
        [JsonProperty("room_rates")]
        public List<RoomRate> RoomRates { get; set; }

        public RoomType(string roomTypeName, List<RoomRate> roomRates)
        {
            this.RoomTypeName = roomTypeName;
            this.RoomRates = roomRates;
        }
    }
}
