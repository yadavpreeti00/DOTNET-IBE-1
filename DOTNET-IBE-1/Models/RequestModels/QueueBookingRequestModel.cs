using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DOTNET_IBE_1.Models.RequestModels
{
    public class QueueBookingRequestModel
    {

        [JsonPropertyName("bookingId")]
        public string? BookingId { get; set; }


        [JsonPropertyName("send_special_offer")]
        public bool SendSpecialOffer { get; set; }

        [Required(ErrorMessage = "First name can't be empty")]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name can't be empty")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number can't be empty")]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Card number can't be empty")]
        [RegularExpression(@"^\d{15,16}$", ErrorMessage = "Please enter valid 15,16-digit card number")]
        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Property ID can't be empty")]
        [JsonPropertyName("property_id")]
        public string PropertyId { get; set; }

        [Required(ErrorMessage = "Check-in date can't be empty")]
        [JsonPropertyName("check_in_date")]
        public string CheckInDate { get; set; }


        [JsonPropertyName("check_out_date")]
        [Required(ErrorMessage = "Check-out date can't be empty")]
        public string CheckOutDate { get; set; }


        [JsonProperty("guests")]
        public string Guests { get; set; }


        [JsonPropertyName("promo_title")]
        public string PromoTitle { get; set; }


        [JsonPropertyName("promo_description")]
        public string PromoDescription { get; set; }


        [JsonPropertyName("subtotal")]
        public string Subtotal { get; set; }


        [JsonPropertyName("taxes")]
        public string Taxes { get; set; }


        [JsonPropertyName("vat")]
        public string Vat { get; set; }


        [JsonPropertyName("total_for_stay")]
        public string TotalForStay { get; set; }


        [JsonPropertyName("room_type")]
        public string RoomType { get; set; }


        [JsonPropertyName("mailing_address1")]
        public string MailingAddress1 { get; set; }


        [JsonPropertyName("mailing_address2")]
        public string MailingAddress2 { get; set; }


        [JsonPropertyName("country")]
        public string Country { get; set; }


        [JsonPropertyName("state")]
        public string State { get; set; }


        [JsonPropertyName("city")]
        public string City { get; set; }


        [JsonPropertyName("zip")]
        public string Zip { get; set; }


        [JsonPropertyName("room_count")]
        public string RoomCount { get; set; }


    }



}
