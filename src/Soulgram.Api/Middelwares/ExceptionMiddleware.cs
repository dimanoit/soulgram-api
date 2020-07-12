using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Soulgram.Api.Middelwares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //TODO add logic to handle different type of the exceptions
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                await WriteResponseAsync(context, HttpStatusCode.InternalServerError, ex);
            }
        }

        private Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(ex.Message);
        }
    }
}
