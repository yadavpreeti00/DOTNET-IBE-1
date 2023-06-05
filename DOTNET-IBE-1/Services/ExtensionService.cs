using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using DOTNET_IBE_1.Entities;
using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Middlewares;
using DOTNET_IBE_1.Services.ClientService.cs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_IBE_1.Services
{
    public static class ExtensionService
    {
        /// <summary>
        /// To register all the services (method is used in Program.cs)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddAWSService<IAmazonDynamoDB>(new AWSOptions
                {
                    Profile = configuration["AWS:Profile"],
                    Region = RegionEndpoint.GetBySystemName(configuration["AWS:Region"])
                })
                //cors configuration
                .AddCors(options =>
                {
                    options.AddPolicy("AllowSpecificOrigins",
                        builder =>
                        {
                            builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                })
                .AddScoped<IConfigurationDataService, ConfigurationDataService>()
                .AddScoped<IPromotionsService, PromotionsService>()
                .AddScoped<IRateService, RateService>()
                .AddScoped<ISearchResultsService, SearchResultsService>()
                .AddScoped<IDatabaseOperationsService, DatabaseOperationsService>()
                .AddScoped<IBookingService, BookingService>()
                .AddScoped<GraphQLClientService>()
                .AddScoped<HttpClient>()
                .AddScoped<ExceptionHandlingMiddleware>()
                .AddHostedService<SQSBackgroundService>()
                .AddScoped<SQSClientService>()
                ;
            return services;
        }

        /// <summary>
        /// To register the database context (method used in Program.cs)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<team03Context>(options =>
            options.UseNpgsql(configuration["ConnectionString:DefaultConnection"]));
            return services;
        }


    }
}
