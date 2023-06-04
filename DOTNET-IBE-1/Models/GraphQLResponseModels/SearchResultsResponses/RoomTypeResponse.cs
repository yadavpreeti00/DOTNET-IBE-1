using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class RoomTypeResponse
    {
        [JsonProperty("property_id")]
        public int PropertyId { get; set; }

        [JsonProperty("room_type_name")]
        public string RoomTypeName { get; set; }
    }
}
