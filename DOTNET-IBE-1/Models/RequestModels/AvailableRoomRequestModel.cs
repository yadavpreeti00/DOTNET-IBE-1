using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DOTNET_IBE_1.Models.RequestModels
{
    public class AvailableRoomRequestModel
    {
        [Required(ErrorMessage = "Check-in date can't be empty")]
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Check-out date can't be empty")]
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Room count can't be empty")]
        [JsonProperty("roomCount")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage ="Property id can't be empty")]
        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }



        [JsonProperty("sortType")]
        public SortTypeRequestModel? SortType { get; set; }

        [JsonProperty("filterTypes")]
        public FilterTypeRequestModel[]? FilterTypes { get; set; }
    }
}
