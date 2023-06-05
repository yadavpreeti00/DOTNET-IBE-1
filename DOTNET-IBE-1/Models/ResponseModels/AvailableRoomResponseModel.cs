using DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses;
using DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses;
using System.Text.Json.Serialization;

namespace DOTNET_IBE_1.Models.ResponseModels
{
    public class AvailableRoomResponseModel
    {
        [JsonPropertyName("roomTypeName")]
        public string RoomTypeName { get; set; }
        [JsonPropertyName("roomTypeId")]
        public string RoomTypeId { get; set; }
        [JsonPropertyName("singleBed")]
        public int SingleBed { get; set; }
        [JsonPropertyName("doubleBed")]
        public int DoubleBed { get; set; }
        [JsonPropertyName("totalBeds")]
        public int TotalBeds { get; set; }
        [JsonPropertyName("maxCapacity")]
        public int MaxCapacity { get; set; }
        [JsonPropertyName("areaInSquareFeet")]
        public int AreaInSquareFeet { get; set; }
        [JsonPropertyName("specialDeal")]
        public bool SpecialDeal { get; set; }
        [JsonPropertyName("specialDealDescription")]
        public string SpecialDealDescription { get; set; }
        [JsonPropertyName("rate")]
        public double Rate { get; set; }
        [JsonPropertyName("rating")]
        public string Rating { get; set; }
        [JsonPropertyName("reviewers")]
        public long Reviewers { get; set; }

        public AvailableRoomResponseModel(string roomTypeName, string roomTypeId, int singleBed, int doubleBed, int totalBeds, int maxCapacity, int areaInSquareFeet, bool specialDeal, string specialDealDescription, double rate, string rating, long reviewers)
        {
            RoomTypeName = roomTypeName;
            RoomTypeId = roomTypeId;
            SingleBed = singleBed;
            DoubleBed = doubleBed;
            TotalBeds = totalBeds;
            MaxCapacity = maxCapacity;
            AreaInSquareFeet = areaInSquareFeet;
            SpecialDeal = specialDeal;
            SpecialDealDescription = specialDealDescription;
            Rate = rate;
            Rating = rating;
            Reviewers = reviewers;
        }

        public AvailableRoomResponseModel(SearchResultRoomType roomType,double rate)
        {
            RoomTypeName = roomType.RoomTypeName;
            RoomTypeId = roomType.RoomTypeId;
            SingleBed = roomType.SingleBed;
            DoubleBed = roomType.DoubleBed;
            TotalBeds = roomType.SingleBed + roomType.DoubleBed;
            MaxCapacity = roomType.MaxCapacity;
            AreaInSquareFeet = (int)roomType.AreaInSquareFeet;
            SpecialDeal = false;
            SpecialDealDescription = null;
            Rate = rate;
            Reviewers = 0L;
            Rating=    "NA";

        }
    }
}
