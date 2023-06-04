using System.Text.Json.Serialization;

namespace DOTNET_IBE_1.Models.ResponseModels
{
    public class BookingStatusResponseModel
    {
        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; } = null!;
        [JsonPropertyName("bookingStatus")]
        public bool BookingStatus { get; set; }
    }
}
