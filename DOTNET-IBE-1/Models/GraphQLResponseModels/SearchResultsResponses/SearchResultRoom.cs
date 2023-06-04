using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class SearchResultRoom
    {
        [JsonProperty("room_type")]
        public SearchResultRoomType RoomType { get; set; }
    }
}
