using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class RoomTypesResponse
    {
        [JsonProperty("room_type")]
        public RoomTypeResponse RoomType { get; set; }

    }
}
