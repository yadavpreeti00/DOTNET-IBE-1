using System;
using System.Collections.Generic;

namespace DOTNET_IBE_1.Entities
{
    public partial class RoomRating
    {
        public string BookingId { get; set; } = null!;
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public bool IsRated { get; set; }
        public bool MailSent { get; set; }
        public string? Review { get; set; }
        public float? RoomRating1 { get; set; }
        public string RoomType { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public long? Version { get; set; }
    }
}
