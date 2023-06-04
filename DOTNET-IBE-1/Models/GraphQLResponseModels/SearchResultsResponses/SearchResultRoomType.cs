using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses
{
    public class SearchResultRoomType
    {
        [JsonProperty("room_type_name")]
        public string RoomTypeName { get; set; }
        [JsonProperty("single_bed")]
        public int SingleBed { get; set; }
        [JsonProperty("room_type_id")]
        public string RoomTypeId { get; set; }
        [JsonProperty("max_capacity")]
        public int MaxCapacity { get; set; }
        [JsonProperty("double_bed")]
        public int DoubleBed { get; set; }
        [JsonProperty("area_in_square_feet")]
        public double AreaInSquareFeet { get; set; }
    }
}
