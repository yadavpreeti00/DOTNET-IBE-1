using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse
{
    public class MinimumNightlyRateResponse
    {
        [JsonProperty("listRoomTypes")]
        public List<MinimumNightlyRateRoomType> ListRoomTypes { get; set; }
    }
}
