using DOTNET_IBE_1.Entities;
using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.PromotionsResponses
{
    public class PromotionGraphQLResponseModel
    {
        [JsonProperty("is_deactivated")]
        public bool IsDeactivated { get; set; }
        [JsonProperty("minimum_days_of_stay")]
        public int MinimumDaysOfStay { get; set; }
        [JsonProperty("price_factor")]
        public float PriceFactor { get; set; }
        [JsonProperty("promotion_description")]
        public string PromotionDescription { get; set; }
        [JsonProperty("promotion_id")]
        public int PromotionId { get; set; }
        [JsonProperty("promotion_title")]
        public string PromotionTitle { get; set; }

        public PromotionGraphQLResponseModel(bool isDeactivated, int minimumDaysOfStay, float priceFactor, string promotionDescription, int promotionId, string promotionTitle)
        {
            IsDeactivated = isDeactivated;
            MinimumDaysOfStay = minimumDaysOfStay;
            PriceFactor = priceFactor;
            PromotionDescription = promotionDescription;
            PromotionId = promotionId;
            PromotionTitle = promotionTitle;
        }

        public PromotionGraphQLResponseModel(CustomPromotion customPromotion)
        {
            IsDeactivated = customPromotion.IsDeactivated;
            MinimumDaysOfStay = customPromotion.MinimumDaysOfStay;
            PriceFactor = customPromotion.PriceFactor;
            PromotionDescription = customPromotion.PromotionDescription;
            PromotionId = customPromotion.PromotionId;
            PromotionTitle = customPromotion.PromotionTitle;
        }

        public PromotionGraphQLResponseModel()
        {
        }
    }
}
