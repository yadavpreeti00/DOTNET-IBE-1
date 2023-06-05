using System.Text.Json.Serialization;

namespace DOTNET_IBE_1.Models.ResponseModels
{
    public class QueueBookingResponseModel
    {
        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; }
    }
}
