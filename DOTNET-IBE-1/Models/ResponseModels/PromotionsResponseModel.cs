using DOTNET_IBE_1.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DOTNET_IBE_1.Models.ResponseModels
{
    public class PromotionsResponseModel
    {
        [JsonProperty("promoCode")]
        public string? PromoCode { get; set; }

        [JsonProperty("isDeactivated")]
        [Required]
        public bool IsDeactivated { get; set; }

        [JsonProperty("minimumDaysOfStay")]
        [Required]
        public int MinimumDaysOfStay { get; set; }

        [JsonProperty("priceFactor")]
        [Required]
        public float PriceFactor { get; set; }

        [JsonProperty("promotionDescription")]
        [Required]
        public string PromotionDescription { get; set; }

        [JsonProperty("promotionTitle")]
        [Required]
        public string PromotionTitle { get; set; }

        [JsonProperty("promotionId")]
        [Required]
        public int PromotionId { get; set; }

        public PromotionsResponseModel(string? promoCode, bool isDeactivated, int minimumDaysOfStay, float priceFactor, string promotionDescription, string promotionTitle, int promotionId)
        {
            PromoCode = promoCode;
            IsDeactivated = isDeactivated;
            MinimumDaysOfStay = minimumDaysOfStay;
            PriceFactor = priceFactor;
            PromotionDescription = promotionDescription;
            PromotionTitle = promotionTitle;
            PromotionId = promotionId;
        }

        public PromotionsResponseModel(CustomPromotion customPromotion)
        {
            PromoCode = customPromotion.PromoCode;
            IsDeactivated = customPromotion.IsDeactivated;
            MinimumDaysOfStay = customPromotion.MinimumDaysOfStay;
            PriceFactor = customPromotion.PriceFactor;
            PromotionDescription = customPromotion.PromotionDescription;
            PromotionTitle = customPromotion.PromotionTitle;
            PromotionId= customPromotion.PromotionId;           }
    }
}
