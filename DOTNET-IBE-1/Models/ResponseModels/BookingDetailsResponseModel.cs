using DOTNET_IBE_1.Entities;

namespace DOTNET_IBE_1.Models.ResponseModels
{
    public class BookingDetailsResponseModel
    {

        
        public string BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? PromoTitle { get; set; }
        public string CardNumber { get; set; }
        public string PropertyId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string Guests { get; set; }
        public string? PromoDescription { get; set; }
        public string NightlyRate { get; set; }
        public string Subtotal { get; set; }
        public string Taxes { get; set; }
        public string Vat { get; set; }
        public string TotalForStay { get; set; }
        public string RoomType { get; set; }
        public List<string>? RoomsList { get; set; }
        public string MailingAddress1 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string RoomCount { get; set; }
        public bool IsDeleted { get; set; }

        public BookingDetailsResponseModel(BookingDetail bookingDetails)
        {
            BookingId = bookingDetails.BookingId;
            FirstName = bookingDetails.FirstName;
            LastName = bookingDetails.LastName;
            Phone = bookingDetails.Phone;
            Email = bookingDetails.Email;
            PromoTitle = bookingDetails.PromoTitle;
            PromoDescription = bookingDetails.PromotionDescription;
            CardNumber = bookingDetails.CardNumber;
            PropertyId = bookingDetails.PropertyId;
            CheckInDate = bookingDetails.CheckInDate;
            CheckOutDate = bookingDetails.CheckOutDate;
            Guests = bookingDetails.Guests;
            NightlyRate = bookingDetails.NightlyRate;
            Subtotal = bookingDetails.Subtotal;
            Taxes = bookingDetails.Taxes;
            Vat = bookingDetails.Vat;
            TotalForStay = bookingDetails.TotalForStay;
            RoomType = bookingDetails.RoomType;
            RoomsList = null;
            MailingAddress1 = bookingDetails.MailingAddress1;
            Country = bookingDetails.Country;
            State = bookingDetails.State;
            Zip = bookingDetails.Zip;
            RoomCount = bookingDetails.RoomCount;
            IsDeleted = bookingDetails.IsDeleted;
        }

        public BookingDetailsResponseModel()
        {
        }
    }
}
