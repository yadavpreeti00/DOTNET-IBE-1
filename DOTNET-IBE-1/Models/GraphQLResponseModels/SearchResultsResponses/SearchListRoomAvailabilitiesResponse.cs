using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class SearchListRoomAvailabilitiesResponse
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("room_id")]
        public int RoomId { get; set; }

        [JsonProperty("room")]
        public SearchResultRoom Room { get; set; }
    }
}
