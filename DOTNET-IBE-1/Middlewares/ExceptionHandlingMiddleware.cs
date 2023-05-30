using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models;

namespace DOTNET_IBE_1.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (GraphQLException ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, 500);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (InvalidRoomTypesListException ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, 500);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (NullGraphQLQueryException ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, 500);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse(ex.Message, context.Request.Path, 500);
                _logger.LogError(jsonErrorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }

        private string GenerateErrorResponse(string message, string path, int statusCode)
        {
            ErrorResponseModel errorResponse = new ErrorResponseModel(message, path, statusCode, DateTime.Now);
            return System.Text.Json.JsonSerializer.Serialize(errorResponse);
        }
    }
}
