using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class SearchRoomRatesQueryResponse
    {
        [JsonProperty("listRoomRates")]
        public List<ListRoomRate> ListRoomTypes { get; set; }

    }
}
