using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.GraphQLResponseModels;
using DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse;
using DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Services.ClientService.cs;
using DOTNET_IBE_1.Utility;

namespace DOTNET_IBE_1.Services
{
    public class RateService : IRateService
    {
        private readonly GraphQLClientService _graphQLClientService;
        public RateService(GraphQLClientService graphQLClientService)
        {
            _graphQLClientService = graphQLClientService;
        }

        /// <summary>
        /// Querys graphql processess the data obtained to get a dictionary containing minimum rate of a particular date 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullGraphQLQueryException"></exception>
        /// <exception cref="GraphQLException"></exception>
        public async Task<Dictionary<string, double>> GetMinimumRateDateMapping()
        {
            int skip = 0;
            int take = 1000;
            string query = 
                GraphQLQueries.minimumNightlyRateQuery
                .Replace("{take}", take.ToString()).Replace("{skip}", skip.ToString());

            GraphQlResponseModel<MinimumNightlyRateResponse> response 
                = await _graphQLClientService
                .SendQueryAsync<GraphQlResponseModel<MinimumNightlyRateResponse>>(query); 

            if(response==null)
            {
                throw new GraphQLException(ExceptionMessages.GRAPH_QL_FAILED);
            }

            List<MinimumNightlyRateRoomType> listRoomTypes = response.Data.ListRoomTypes;
            Dictionary<string,double> minimumNightlyRateDictionary
                = RateUtil.GetDateToRateMappingFromRoomTypesList(listRoomTypes);
            return minimumNightlyRateDictionary;
        }

        /// <summary>
        /// Gets the price break down request and process it to get rate against each date of stay for checkout 
        /// </summary>
        /// <param name="priceBreakdownRequest"></param>
        /// <returns>dictionary of date : rate </returns>
        /// <exception cref="GraphQLException"></exception>
        public async Task<Dictionary<string, int>> GetPriceBreakDown(PriceBreakdownRequestModel priceBreakdownRequest)
        {

            var response = await _graphQLClientService
                .SendQueryAsync<GraphQlResponseModel<RoomRatesResponseData>>(GraphQLQueries.roomRatesBreakDown);
            if (response == null)
            {
                throw new GraphQLException(ExceptionMessages.FAILED_TO_RETRIEVE_PRICE_BREAKDOWN);
            }
            Dictionary<string, int> priceBreakDownResult = new Dictionary<string, int>();
            RateUtil.GetPriceBreakdown(response.Data, priceBreakdownRequest, priceBreakDownResult);
            return priceBreakDownResult;

        }
    }
}
