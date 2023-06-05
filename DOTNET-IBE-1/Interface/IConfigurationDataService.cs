using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Interface
{
    public interface IConfigurationDataService
    {
        public Task<ConfigurationDataResponseModel> GetLandingPageConfigurationData();
        public Task<ConfigurationDataResponseModel> GetRoomResultsPageConfigurationData();
        public Task<ConfigurationDataResponseModel> GetCheckoutPageConfigurationData();

    }
}
