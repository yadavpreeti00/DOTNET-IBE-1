namespace DOTNET_IBE_1.Interface
{
    public interface IRateService
    {
        public  Task<Dictionary<string, double>> GetMinimumRateDateMapping();

    }
}
