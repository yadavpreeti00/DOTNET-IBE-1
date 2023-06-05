using System;
using System.Collections.Generic;

namespace DOTNET_IBE_1.Entities
{
    public partial class RoomTypeRoomId
    {
        public Guid Id { get; set; }
        public string BookingId { get; set; } = null!;
        public string Date { get; set; } = null!;
        public int RoomId { get; set; }
        public string RoomType { get; set; } = null!;
    }
}
