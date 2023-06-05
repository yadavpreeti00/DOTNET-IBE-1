using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Services;
using DOTNET_IBE_1.Utility;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_IBE_TESTS
{
    public class BookingServiceTests
    {
        [Fact]
        public void GetBookingDetailsForUserReturnsSortedBookingDetails()
        {
            // Arrange
            string userId = "user123";
            DatabaseOperationsService databaseOperationsService = new DatabaseOperationsService();

            // Create the bookingDetails list with example values
            List<BookingDetail> bookingDetails = new List<BookingDetail>()
            {
                new BookingDetail
                {
                    BookingId = "ABC123",
                    CardNumber = "1234567890",
                    CheckInDate = "2023-06-01",
                    CheckOutDate = "2023-06-05",
                    Country = "United States",
                    CreatedAt = DateTime.Now,
                    Email = "example@example.com",
                    FirstName = "John",
                    Guests = "2",
                    IsDeleted = false,
                    LastName = "Doe",
                    MailingAddress1 = "123 Main St",
                    NightlyRate = "150.00",
                    Phone = "123-456-7890",
                    PromotionDescription = "Summer Discount",
                    PromoTitle = "Summer Sale",
                    PropertyId = "XYZ123",
                    RoomCount = "1",
                    RoomType = "Standard",
                    RoomsList = "Room 1, Room 2",
                    State = "California",
                    Subtotal = "300.00",
                    Taxes = "30.00",
                    TotalForStay = "330.00",
                    UpdatedAt = DateTime.Now,
                    Vat = "15.00",
                    Zip = "12345",
                    UserId = "user123",
                    CustomPromotionPromoCode = "CUSTOM123"
                },
                new BookingDetail
                {
                    BookingId = "DEF456",
                    CardNumber = "0987654321",
                    CheckInDate = "2023-07-01",
                    CheckOutDate = "2023-07-05",
                    Country = "Canada",
                    CreatedAt = DateTime.Now,
                    Email = "example2@example.com",
                    FirstName = "Jane",
                    Guests = "1",
                    IsDeleted = false,
                    LastName = "Smith",
                    MailingAddress1 = "456 Maple Ave",
                    NightlyRate = "200.00",
                    Phone = "987-654-3210",
                    PromotionDescription = "Winter Special",
                    PromoTitle = "Winter Getaway",
                    PropertyId = "PQR789",
                    RoomCount = "2",
                    RoomType = "Deluxe",
                    RoomsList = "Room 3, Room 4",
                    State = "Ontario",
                    Subtotal = "400.00",
                    Taxes = "40.00",
                    TotalForStay = "440.00",
                    UpdatedAt = DateTime.Now,
                    Vat = "20.00",
                    Zip = "67890",
                    UserId = "user456",
                    CustomPromotionPromoCode = "CUSTOM456"
                }
            };

            var mockDatabaseOperationsService = new Mock<IDatabaseOperationsService>();
            mockDatabaseOperationsService.Setup(service => service.GetBookingDetailsForUser(userId))
                .Returns(bookingDetails);

            BookingService bookingService = new BookingService(mockDatabaseOperationsService.Object);

            // Act
            List<BookingDetail> result = bookingService.GetBookingDetailsForUser(userId);
            // Assert
            Assert.Equal(bookingDetails.Count, result.Count);
            // Verify that the returned bookingDetails list is sorted by check-in date
            DateTime previousCheckInDate = DateTime.MaxValue;
            foreach (var bookingDetail in result)
            {
                DateTime checkInDate = DateUtil.ConvertToDate(bookingDetail.CheckInDate);
                Assert.True(checkInDate <= previousCheckInDate);
                previousCheckInDate = checkInDate;
            }
        }

        [Fact]
        public void GetBookingDetailsForUserWithInvalidUserId()
        {
            // Arrange
            string userId = "invalidUserId";
            var mockDatabaseOperationsService = new Mock<IDatabaseOperationsService>();
            mockDatabaseOperationsService
                .Setup(service => service.GetBookingDetailsForUser(userId))
                .Returns(new List<BookingDetail>()); 
            var bookingService = new BookingService(mockDatabaseOperationsService.Object);
            // Act
            List<BookingDetail> result = bookingService.GetBookingDetailsForUser(userId);
            // Assert
            Assert.Empty(result);
        }

    }
}
