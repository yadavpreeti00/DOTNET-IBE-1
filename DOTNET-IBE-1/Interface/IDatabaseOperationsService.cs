using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Interface
{
    public interface IDatabaseOperationsService
    {
        public Task<CustomPromotion> GetCustomPromotionByPromoCode(string promoCode);
        public BookingStatusResponseModel GetBookingStatusFromBookingId(string bookingId);
        public BookingStatus SetBookingStatus(string bookingId, bool status);
        public BookingDetail SetBookingDetails(BookingDetail bookingDetail);
        public BookingDetailsResponseModel GetBookingDetailsFromBookingId(string bookingId);
        public void CancelBookingFromBookingId(string bookingId);
        public List<BookingDetail> GetBookingDetailsForUser(string userId);






    }
}
