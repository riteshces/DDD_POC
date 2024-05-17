﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace POC_Invoicemgmt.Exceptions
{
    public class AddExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotImplementedException)
            {
                var response = new ExceptionResponse()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = exception.Message,
                    Title = "Something went wrong"
                };

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return true;
            }
            else if (exception is NotImplementedException)
            {
                var response = new ExceptionResponse()
                {
                    StatusCode = StatusCodes.Status501NotImplemented,
                    Message = exception.Message,
                    Title = "Something went wrong"
                };

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                return true;
            }

            return false;
        }
    }

    
}
