using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Models.GraphQLResponseModels.PromotionsResponses;
using DOTNET_IBE_1.Models.RequestModels;

namespace DOTNET_IBE_1.Utility
{
    public static class PromotionUtil
    {
        /// <summary>
        /// Checks for valid promotion from promotion request body
        /// </summary>
        /// <param name="promotionResponse"></param>
        /// <param name="stayRange"></param>
        /// <param name="promotionRequest"></param>
        /// <returns>true : promotion valid, false : invalid promotion</returns>
        public static bool CheckValidPromotion(PromotionGraphQLResponseModel promotionResponse, long stayRange, PromotionRequestModel promotionRequest)
        {
            bool minimumStay = stayRange >= promotionResponse.MinimumDaysOfStay;
            bool validPromotion;

            switch (promotionResponse.PromotionTitle)
            {
                case CommonConstants.SENIOR_CITIZEN_DISCOUNT:
                case CommonConstants.MILITARY_PERSONNEL_DISCOUNT:
                case CommonConstants.KDU_MEMBERSHIP_DISCOUNT:
                case CommonConstants.DISABLED_DISCOUNT:
                    validPromotion = promotionRequest.ApplicableDiscountType != null 
                        && promotionResponse.PromotionTitle
                        .Equals(promotionRequest.ApplicableDiscountType, StringComparison.OrdinalIgnoreCase);
                    break;
                case CommonConstants.LONG_WEEKEND_DISCOUNT:
                case CommonConstants.WEEKEND_DISCOUNT:
                    validPromotion = DateUtil.CheckWeekend(promotionRequest.StartDate, 
                        promotionRequest.EndDate, CommonConstants.ALL_WEEKEND);
                    break;
                case CommonConstants.WEEKDAYS_DISCOUNT:
                    validPromotion = !DateUtil.CheckWeekend(promotionRequest.StartDate, 
                        promotionRequest.EndDate, CommonConstants.ANY_WEEKEND);
                    break;
                default:
                    validPromotion = true;
                    break;
            }


            return minimumStay && validPromotion;
        }
    }
}
