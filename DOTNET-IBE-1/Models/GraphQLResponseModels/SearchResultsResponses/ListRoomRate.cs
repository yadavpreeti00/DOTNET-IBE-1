using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class ListRoomRate
    {
        [JsonProperty("basic_nightly_rate")]
        public int BasicNightlyRate { get; set; }

        [JsonProperty("room_types")]
        public List<RoomTypesResponse> RoomTypes { get; set; }
    }

}
