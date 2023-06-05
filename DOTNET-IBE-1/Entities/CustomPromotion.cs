using System;
using System.Collections.Generic;

namespace DOTNET_IBE_1.Entities
{
    public partial class CustomPromotion
    {
        public CustomPromotion()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public string PromoCode { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public bool IsDeactivated { get; set; }
        public int MinimumDaysOfStay { get; set; }
        public float PriceFactor { get; set; }
        public string PromotionDescription { get; set; } = null!;
        public int PromotionId { get; set; }
        public string PromotionTitle { get; set; } = null!;
        public string? ApplicableRoomType { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
