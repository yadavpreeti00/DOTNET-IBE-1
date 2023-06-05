using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Interface
{
    public interface IBookingService
    {
        public BookingStatusResponseModel GetBookingStatus(string bookingId);
        public BookingDetailsResponseModel GetBookingDetails(string bookingId);
        public string CancelBooking(string bookingId);
        public List<BookingDetail> GetBookingDetailsForUser(string userId);
        public bool CreateBooking(string bookingRequestFromQueue);


    }
}
