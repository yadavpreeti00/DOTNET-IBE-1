using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class SearchResultsQueryResponse
    {
        [JsonProperty("listRoomAvailabilities")]
        public List<SearchListRoomAvailabilitiesResponse> ListRoomAvailabilities { get; set; }
    }
}
