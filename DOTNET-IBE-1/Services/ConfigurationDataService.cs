using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Services
{
    public class ConfigurationDataService : IConfigurationDataService
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private readonly IConfiguration _configuration;

        public ConfigurationDataService(IAmazonDynamoDB dynamoDbClient, IConfiguration configuration)
        {
            _dynamoDbClient = dynamoDbClient;
            _configuration = configuration;
        }

        public async Task<ConfigurationDataResponseModel> GetCheckoutPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]

            };
            var response = await _dynamoDbClient.ScanAsync(request);
            if (response.Items.Count > 0)
            {
                var item = response.Items[0];

                var configurationItem = new ConfigurationDataResponseModel
                {
                    TenantId = item["tenantId"].S,
                    Page = "CheckoutPage",
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new NotFoundException(ExceptionMessages.CHECKOUT_PAGE_CONFIGURATION_NOT_FOUND);
            }
        }
        public async Task<ConfigurationDataResponseModel> GetLandingPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]

            };
            var response = await _dynamoDbClient.ScanAsync(request);
            if (response.Items.Count > 0)
            {
                var item = response.Items[1];

                var configurationItem = new ConfigurationDataResponseModel
                {
                    TenantId = item["tenantId"].S,
                    Page = item["page"].S,
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new NotFoundException(ExceptionMessages.CHECKOUT_PAGE_CONFIGURATION_NOT_FOUND);
            }
        }

        public async Task<ConfigurationDataResponseModel> GetRoomResultsPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]
            };

            var response = await _dynamoDbClient.ScanAsync(request);
            if (response.Items.Count > 0)
            {
                var item = response.Items[2];
                var configurationItem = new ConfigurationDataResponseModel
                {
                    TenantId = item["tenantId"].S,
                    Page = "RoomResultsPage",
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new NotFoundException(ExceptionMessages.ROOM_RESULTS_PAGE_CONFIGURATION_NOT_FOUND);
            }
        }

        
    }
}
