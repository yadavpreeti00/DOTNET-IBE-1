using DOTNET_IBE_1.Interface;
using DOTNET_IBE_1.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace DOTNET_IBE_1.Services
{
    public static class ExtensionService
    {
        /// <summary>
        /// To register all the services (method is used in program.cs)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IRateService, RateService>()
                .AddScoped<GraphQLClientService>()
                .AddScoped<HttpClient>()
                .AddScoped<ExceptionHandlingMiddleware>()
;
            return services;
        }


    }
}
