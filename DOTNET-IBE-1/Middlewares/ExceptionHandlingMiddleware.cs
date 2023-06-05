﻿using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.ResponseModels;
using System.Net;

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
            catch(BadRequestException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ex.Message, context.Request.Path, (int)HttpStatusCode.InternalServerError);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (GraphQLException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path,
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path, 
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (CredentialsException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path, 
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);
                await context.Response.WriteAsync(jsonErrorResponse);

            }
            catch(ParsingException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path, 
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            catch (SQSException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path, 
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);
                await context.Response.WriteAsync(jsonErrorResponse);

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                string jsonErrorResponse = GenerateErrorResponse
                    (ExceptionMessages.INTERNAL_SERVER_ERROR, context.Request.Path, 
                    (int)HttpStatusCode.InternalServerError);
                LogError(ex.Message, ExceptionMessages.UNKNOWN_EXCEPTION);
                LogError(ex.StackTrace, ExceptionMessages.STACKTRACE_UNAVAILABLE);

                
                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }

        private string GenerateErrorResponse(string message, string path, int statusCode)
        {
            ErrorResponseModel errorResponse = 
                new ErrorResponseModel(message, path, statusCode, DateTime.Now);
            return System.Text.Json.JsonSerializer.Serialize(errorResponse);
        }

        private void LogError(string errorMessage, string defaultErrorMessage)
        {
            string message = string.IsNullOrEmpty(errorMessage) ? defaultErrorMessage : errorMessage;
            _logger.LogError(message);
        }
    }
}
