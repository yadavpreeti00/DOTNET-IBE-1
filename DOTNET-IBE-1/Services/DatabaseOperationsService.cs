using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_IBE_1.Services
{
    public class DatabaseOperationsService : IDatabaseOperationsService
    {
        private readonly team03Context _team03Context;
        public DatabaseOperationsService(team03Context team03Context)
        {
            _team03Context = team03Context;
        }

        public DatabaseOperationsService()
        {
        }

        public async Task<CustomPromotion> GetCustomPromotionByPromoCode(string promoCode)
        {
            CustomPromotion? customPromotion = await _team03Context.CustomPromotions
                .FirstOrDefaultAsync(p => p.PromoCode == promoCode);
            return customPromotion;
        }

        public BookingStatusResponseModel GetBookingStatusFromBookingId(string bookingId)
        {
            BookingStatus? bookingStatus = _team03Context.BookingStatuses.Find(bookingId);

            if (bookingStatus == null)
            {
                throw new NotFoundException(ExceptionMessages.BOOKING_STATUS_NOT_FOUND);
            }
            BookingStatusResponseModel response = new BookingStatusResponseModel
            {
                BookingId = bookingStatus.BookingId,
                BookingStatus = bookingStatus.BookingStatus1
            };
            return response;
        }

        public BookingStatus SetBookingStatus(string bookingId, bool status)
        {
            BookingStatus bookingStatus = new BookingStatus
            {
                BookingId = bookingId,
                BookingStatus1 = status
            };

            _team03Context.BookingStatuses.Add(bookingStatus);
            _team03Context.SaveChanges();
            return bookingStatus;
        }


        public BookingDetail SetBookingDetails(BookingDetail bookingDetail)
        {
            _team03Context.BookingDetails.Add(bookingDetail);
            _team03Context.SaveChanges();
            return bookingDetail;
        }

        public BookingDetailsResponseModel GetBookingDetailsFromBookingId(string bookingId)
        {
            BookingDetail? bookingDetails = _team03Context.BookingDetails
                .Find(bookingId);
            if (bookingDetails == null)
            {
                throw new NotFoundException(ExceptionMessages.BOOKING_DETAILS_NOT_FOUND);
            }
            BookingDetailsResponseModel response = new BookingDetailsResponseModel(bookingDetails);
            return response;
        }

        public void CancelBookingFromBookingId(string bookingId)
        {
            BookingDetail? bookingDetails = _team03Context.BookingDetails.Find(bookingId);
            if (bookingDetails == null)
            {
                throw new NotFoundException(ExceptionMessages.BOOKING_DETAILS_NOT_FOUND);
            }
            bookingDetails.IsDeleted = true;
            _team03Context.SaveChanges();
        }

        public List<BookingDetail> GetBookingDetailsForUser(string userId)
        {
            var bookingDetails = _team03Context.BookingDetails.Where(b => b.UserId == userId).ToList();
            if (bookingDetails.Count == 0)
            {
                throw new NotFoundException(ExceptionMessages.BOOKING_DETAILS_NOT_FOUND);
            }
            return bookingDetails;
        }
    }
}
