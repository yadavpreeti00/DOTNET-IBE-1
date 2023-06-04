using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Interface
{
    public interface IPromotionsService
    {
        public Task<HashSet<PromotionsResponseModel>> GetDefaultPromotions(PromotionRequestModel promotionRequest);

        public Task<PromotionsResponseModel> GetCustomPromotion(PromotionRequestModel promotionRequest);

    }
}
