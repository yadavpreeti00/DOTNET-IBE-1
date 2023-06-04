using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Interface
{
    public interface ISearchResultsService
    {
        public Task<List<AvailableRoomResponseModel>> GetSearchResults(AvailableRoomRequestModel availableRoomRequest);

    }
}
