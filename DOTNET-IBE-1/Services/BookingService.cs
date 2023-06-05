using Amazon.SQS.Model;
using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;
using DOTNET_IBE_1.Utility;
using Newtonsoft.Json;
using System.Globalization;

namespace DOTNET_IBE_1.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDatabaseOperationsService _databaseOperationsService;
        public BookingService(IDatabaseOperationsService databaseOperationsService)
        {
            _databaseOperationsService = databaseOperationsService;
        }

        public BookingService()
        {
        }

        public bool CreateBooking(string bookingRequestFromQueue)
        {
            QueueBookingRequestModel? bookingRequest = 
                JsonConvert.DeserializeObject<QueueBookingRequestModel>(bookingRequestFromQueue);
            if (bookingRequest == null)
            {
                throw new ParsingException(ExceptionMessages.FAILED_TO_PARSE_QUEUE_REQUEST);
            }
            DateTime startDate = DateUtil.ConvertUTCStringToDate(bookingRequest.CheckInDate);
            DateTime endDate = DateUtil.ConvertUTCStringToDate(bookingRequest.CheckOutDate);
            int numOfDays = (int)(endDate - startDate).TotalDays;
            double totalPrice;
            bool success = double.TryParse(bookingRequest.TotalForStay, out totalPrice);
            if (!success)
            {
                throw new ParsingException(ExceptionMessages.FAILED_TO_PARSE_QUEUE_REQUEST_TOTAL_FOR_STAY);
            }
            double nightlyRate = totalPrice / numOfDays;

            BookingDetail bookingDetail = new BookingDetail(bookingRequest, nightlyRate);
            _databaseOperationsService.SetBookingDetails(bookingDetail);
            _databaseOperationsService.SetBookingStatus(bookingDetail.BookingId, true);
            return true;
        }

        public string CancelBooking(string bookingId)
        {
            _databaseOperationsService.CancelBookingFromBookingId(bookingId);
            return CommonConstants.BOOKING_CANCELLED_SUCCESSFULLY;
        }

        public BookingDetailsResponseModel GetBookingDetails(string bookingId)
        {
            return _databaseOperationsService.GetBookingDetailsFromBookingId(bookingId);
        }

        public List<BookingDetail> GetBookingDetailsForUser(string userId)
        {
            List<BookingDetail> bookingDetails = _databaseOperationsService
                .GetBookingDetailsForUser(userId);

            // Sorting the bookingDetails list by check-in date
            bookingDetails.Sort((b1, b2) =>
            {
                DateTime checkInDate1 = DateUtil.ConvertToDate(b1.CheckInDate);
                DateTime checkInDate2 = DateUtil.ConvertToDate(b2.CheckInDate);
                return checkInDate2.CompareTo(checkInDate1);
            });

            return bookingDetails;

        }

        public BookingStatusResponseModel GetBookingStatus(string bookingId)
        {
            return _databaseOperationsService.GetBookingStatusFromBookingId(bookingId);
        }
    }
}

