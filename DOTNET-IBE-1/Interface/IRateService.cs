using DOTNET_IBE_1.Models.RequestModels;

namespace DOTNET_IBE_1.Interface
{
    public interface IRateService
    {
        public  Task<Dictionary<string, double>> GetMinimumRateDateMapping();
        public Task<Dictionary<string, int>> GetPriceBreakDown(PriceBreakdownRequestModel priceBreakdownRequest);

    }
}
