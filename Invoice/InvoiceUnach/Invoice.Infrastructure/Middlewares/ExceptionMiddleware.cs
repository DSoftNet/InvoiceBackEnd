using FluentValidation;
using FluentValidation.Results;
using Invoice.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogInformation("Loggin Exception");

            string response;

            if (exception is DomainException domainException)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)(domainException.HttpStatusCode ?? HttpStatusCode.BadRequest);

                List<string> errors = GetErrors(domainException);

                response = JsonConvert.SerializeObject(new
                {
                    message = domainException.Message,
                    errors
                });

                _logger.LogInformation(exception, "NotificationDomainException");
            }
            else
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                response = JsonConvert.SerializeObject(new
                {
                    message = exception.Message,
                    errors = exception.InnerException?.ToString()
                });

                _logger.LogInformation(exception, "Internal Server Error");
            }

            await context.Response.WriteAsync(response);

        }

        private List<string> GetErrors(DomainException domainException)
        {
            var errors = new List<string>();

            if (domainException.InnerException != null)
            {
                if (domainException.InnerException is ValidationException)
                {
                    foreach (ValidationFailure error in ((ValidationException)domainException.InnerException).Errors)
                    {
                        errors.Add(error.ToString());
                    }
                }
                else
                {
                    errors.Add(domainException.InnerException?.Message);
                }
            }

            return errors;
        }
    }
}
