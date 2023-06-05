using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;
using DOTNET_IBE_1.Services.ClientService.cs;
using DOTNET_IBE_1.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_IBE_1.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly SQSClientService _sqsService;
        private readonly IBookingService _bookingService;
        
        public BookingController(SQSClientService sqsService,IBookingService bookingService)
        {
            _sqsService = sqsService;
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("/PushBooking")]
        public async Task<IActionResult> PushBooking( QueueBookingRequestModel bookingRequest)
        {
            bookingRequest.BookingId = BookingUtil.GenerateRandomBookingId();
            QueueBookingResponseModel response =await _sqsService.SendMessageToSQS(bookingRequest);
            return Ok(response);
        }

        [HttpGet("BookingStatus/{bookingId}")]
        public IActionResult GetBookingStatus(string bookingId)
        {
            var response = _bookingService.GetBookingStatus(bookingId);
            return Ok(response);
        }

        [HttpGet("BookingDetails/{bookingId}")]
        public IActionResult GetBookingDetails(string bookingId)
        {
            var response = _bookingService.GetBookingDetails(bookingId);
            return Ok(response);
        }

        [HttpPost("CancelBooking/{bookingId}")]
        public IActionResult CancelBooking(string bookingId)
        {
            var response = _bookingService.CancelBooking(bookingId);
            return Ok(response);
        }

        [HttpGet("MyBookings/{userId}")]
        public IActionResult GetBookingDetailsForUser(string userId)
        {
            List<BookingDetail> bookingDetailsList = _bookingService.GetBookingDetailsForUser(userId);
            return Ok(bookingDetailsList);
        }

    }
}
