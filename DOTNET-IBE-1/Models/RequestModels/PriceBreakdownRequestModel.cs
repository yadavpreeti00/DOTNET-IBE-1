using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.RequestModels
{
    public class PriceBreakdownRequestModel
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
        [JsonProperty("roomCount")]
        public int RoomCount { get; set; }
        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }
        [JsonProperty("roomType")]
        public string RoomType { get; set; }
    }
}
