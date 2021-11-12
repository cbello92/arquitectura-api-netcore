using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Arquitectura.Core.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                var result = JsonSerializer.Serialize(new { success = false, errors = error?.Message, statusCode = response.StatusCode });
                await response.WriteAsync(result);
            }
            catch (Exception error)
            {

                var response = context.Response;
                BussinessException err = null;
                response.ContentType = "application/json";
                
                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case BussinessException e:
                        err = e;
                        Console.WriteLine(e);
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                //Console.WriteLine(error);

                var result = JsonSerializer.Serialize(new { success = false, errors = err ?? error, statusCode = response.StatusCode });
                await response.WriteAsync(result);
            }
        }
    }
}
