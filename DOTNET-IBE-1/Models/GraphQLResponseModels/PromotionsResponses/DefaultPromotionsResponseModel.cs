namespace DOTNET_IBE_1.Models.GraphQLResponseModels.PromotionsResponses
{
    public class DefaultPromotionsResponseModel
    {
        public List<PromotionGraphQLResponseModel> ListPromotions { get; set; }

        public DefaultPromotionsResponseModel(List<PromotionGraphQLResponseModel> listPromotions)
        {
            ListPromotions = listPromotions;
        }

        public DefaultPromotionsResponseModel()
        {
        }
    }
}
