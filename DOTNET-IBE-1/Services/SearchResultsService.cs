using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Models.GraphQLResponseModels;
using DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;
using DOTNET_IBE_1.Services.ClientService.cs;
using DOTNET_IBE_1.Utility;

namespace DOTNET_IBE_1.Services
{
    public class SearchResultsService : ISearchResultsService
    {
        private readonly GraphQLClientService _graphQLClientService;
        public SearchResultsService(GraphQLClientService graphQLClientService)
        {
            _graphQLClientService = graphQLClientService;
        }

        /// <summary>
        /// Runs two graphql queries using search request data and processes the response.
        /// </summary>
        /// <param name="availableRoomRequestBody"></param>
        /// <returns>Available room results search model</returns>
        /// <exception cref="GraphQLException"></exception>
        public async Task<List<AvailableRoomResponseModel>> GetSearchResults(AvailableRoomRequestModel availableRoomRequestBody)
        {
            long stayRange = DateUtil
                .GetStayRange(availableRoomRequestBody.StartDate, availableRoomRequestBody.EndDate);   
            
            //Calulate the average rate against each room type name
            string query = GraphQLQueries.rateBetweenDateRangeQuery
                .Replace("$startDate", availableRoomRequestBody.StartDate)
                .Replace("$endDate", availableRoomRequestBody.EndDate);
            GraphQlResponseModel<SearchRoomRatesQueryResponse> response = await 
                _graphQLClientService.SendQueryAsync<GraphQlResponseModel<SearchRoomRatesQueryResponse>>(query);
            if (response == null)
            {
                throw new GraphQLException(ExceptionMessages.GRAPH_QL_FAILED);
            }
            Dictionary<string, double> roomRatesResult = RateUtil
                .CalculateAverageRatePerStay(response.Data, stayRange, availableRoomRequestBody.PropertyId);
            
            //Gets the search results response model
            string searchResultsQuery = GraphQLQueries.searchResultsQuery
                .Replace("$startDate", availableRoomRequestBody.StartDate)
                .Replace("$endDate", availableRoomRequestBody.EndDate);
            var searchResultsResponse = await 
                _graphQLClientService.SendQueryAsync<GraphQlResponseModel<SearchResultsQueryResponse>>
                (searchResultsQuery);
            if (searchResultsResponse == null)
            {
                throw new GraphQLException(ExceptionMessages.GRAPH_QL_FAILED);
            }
            List<AvailableRoomResponseModel> availableRoomsResults = new List<AvailableRoomResponseModel>();
            SearchResultsUtil.FormAvailableRoomResultsResponse(roomRatesResult, searchResultsResponse.Data, 
                stayRange, availableRoomRequestBody.RoomCount, availableRoomsResults);

            if(availableRoomRequestBody.SortType!=null)
            {
                FilterSortUtil.ApplySort(availableRoomRequestBody.SortType, availableRoomsResults);
            }
            if(availableRoomRequestBody.FilterTypes!=null)
            {
                FilterSortUtil.ApplyFilterOptions(availableRoomRequestBody.FilterTypes, availableRoomsResults);
            }

            return availableRoomsResults;
        }

    }
}
