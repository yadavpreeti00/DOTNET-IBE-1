using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.GraphQLResponseModels;
using DOTNET_IBE_1.Models.GraphQLResponseModels.PromotionsResponses;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;
using DOTNET_IBE_1.Services.ClientService.cs;
using DOTNET_IBE_1.Utility;

namespace DOTNET_IBE_1.Services
{
    public class PromotionsService : IPromotionsService
    {
        private readonly GraphQLClientService _graphQLClientService;
        private readonly IDatabaseOperationsService _databaseService;
        public PromotionsService(GraphQLClientService graphQLClientService,IDatabaseOperationsService databaseService)
        {
            _graphQLClientService = graphQLClientService;
            _databaseService = databaseService;
        }

        /// <summary>
        /// Gets the dedault promotions from graph ql and process it.
        /// </summary>
        /// <param name="promotionRequestBody"></param>
        /// <returns>Hashset of all deafault promotions</returns>
        /// <exception cref="GraphQLException"></exception>
        public async Task<HashSet<PromotionsResponseModel>> GetDefaultPromotions
            (PromotionRequestModel promotionRequestBody)
        {
            //get default promotion from graphql
            GraphQlResponseModel<DefaultPromotionsResponseModel> response = 
                await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<DefaultPromotionsResponseModel>>
                (GraphQLQueries.defaultPromotions);
            if(response==null)
            {
                throw new GraphQLException(ExceptionMessages.GRAPH_QL_FAILED);
            }

            List<PromotionGraphQLResponseModel> promos = response.Data.ListPromotions;
            long stayRange = DateUtil.GetStayRange(promotionRequestBody.StartDate, promotionRequestBody.EndDate);
            HashSet<PromotionsResponseModel> promotionsResponseSet = promos
              .Where(promo => !promo.IsDeactivated && 
              PromotionUtil.CheckValidPromotion(promo, stayRange, promotionRequestBody))
              .Select(promo => new PromotionsResponseModel
              (null, promo.IsDeactivated, promo.MinimumDaysOfStay, promo.PriceFactor, promo.PromotionDescription, 
              promo.PromotionTitle, promo.PromotionId))
              .ToHashSet();
            return promotionsResponseSet;
        }

        /// <summary>
        /// Gets custom promotion from database and checks for valid promo conditions from promotion reuqest
        /// </summary>
        /// <param name="promotionRequestBody"></param>
        /// <returns>Returns Custom Promotion model if all promo conditions are valid</returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<PromotionsResponseModel> GetCustomPromotion(PromotionRequestModel promotionRequestBody)
        {
            string? promoCode = promotionRequestBody.PromoCode;
            if(promoCode == null) 
            {
                throw new BadRequestException(ExceptionMessages.PROMO_CODE_EMPTY);
            }

            CustomPromotion? customPromotion = await _databaseService.GetCustomPromotionByPromoCode(promoCode);
            if (customPromotion == null)
            {
                throw new BadRequestException(ExceptionMessages.PROMO_CODE_INVALID);
            }

            // promotions response to return if conditions are valid
            PromotionsResponseModel promotionsResponse = new PromotionsResponseModel(customPromotion);
            
            long stayRange = DateUtil.GetStayRange(promotionRequestBody.StartDate, promotionRequestBody.EndDate);
            
            //promotion response model(graphql type) to pass to the validator function
            PromotionGraphQLResponseModel promotionResponseModel = new PromotionGraphQLResponseModel(customPromotion);
            
            //check for valid promo conditions
            if (!customPromotion.IsDeactivated &&
                    PromotionUtil.CheckValidPromotion(promotionResponseModel, stayRange, promotionRequestBody) &&
                    promotionRequestBody.RoomType.Contains(customPromotion.ApplicableRoomType))
            {
                return promotionsResponse;
            }
            else
            {
                throw new BadRequestException(ExceptionMessages.PROMO_CONDITIONS_INVALID);
            }
        }
    }
}
