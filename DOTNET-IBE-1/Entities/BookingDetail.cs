using DOTNET_IBE_1.Models.RequestModels;
using System;
using System.Collections.Generic;

namespace DOTNET_IBE_1.Entities
{
    public partial class BookingDetail
    {
        public string BookingId { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string CheckInDate { get; set; } = null!;
        public string CheckOutDate { get; set; } = null!;
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Guests { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? LastName { get; set; }
        public string? MailingAddress1 { get; set; }
        public string NightlyRate { get; set; } = null!;
        public string? Phone { get; set; }
        public string? PromotionDescription { get; set; }
        public string? PromoTitle { get; set; }
        public string PropertyId { get; set; } = null!;
        public string? RoomCount { get; set; }
        public string RoomType { get; set; } = null!;
        public string? RoomsList { get; set; }
        public string? State { get; set; }
        public string? Subtotal { get; set; }
        public string? Taxes { get; set; }
        public string TotalForStay { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string? Vat { get; set; }
        public string? Zip { get; set; }
        public string? UserId { get; set; }
        public string? CustomPromotionPromoCode { get; set; }

        public virtual CustomPromotion? CustomPromotionPromoCodeNavigation { get; set; }

        public BookingDetail(QueueBookingRequestModel bookingRequest,double nightlyRate)
        { 
            BookingId = bookingRequest.BookingId;
            CardNumber = bookingRequest.CardNumber;
            CheckInDate = bookingRequest.CheckInDate;
            CheckOutDate = bookingRequest.CheckOutDate;
            Country = bookingRequest.Country;
            CreatedAt = DateTime.Now;
            Email = bookingRequest.Email;
            FirstName = bookingRequest.FirstName;
            Guests = bookingRequest.Guests;
            IsDeleted = false;
            LastName = bookingRequest.LastName;
            MailingAddress1 = bookingRequest.MailingAddress1;
            NightlyRate = nightlyRate.ToString("0.00");
            Phone = bookingRequest.Phone;
            PromotionDescription = bookingRequest.PromoDescription;
            PromoTitle = bookingRequest.PromoTitle;
            PropertyId =bookingRequest.PropertyId;
            RoomCount =bookingRequest.RoomCount;
            RoomType = bookingRequest.RoomType;
            RoomsList = null;
            State = bookingRequest.State;
            Subtotal = bookingRequest.State;
            Taxes = bookingRequest.Taxes;
            TotalForStay = bookingRequest.TotalForStay;
            UpdatedAt = DateTime.Now;
            Vat = bookingRequest.Vat;
            Zip = bookingRequest.Zip;
            if(bookingRequest.UserId != null)
            {
                UserId = bookingRequest.UserId;
            }
            CustomPromotionPromoCode = null;
        }

        public BookingDetail()
        {
        }
    }
}
