using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Exceptions
{
    /// <summary>
    /// Middle to handle excptions at Global level
    /// </summary>
    /// <ref>https://www.youtube.com/watch?v=Cy53ENszjWo</ref>
    /// <ref>https://ankitvijay.net/2021/04/21/consistent-error-handling/</ref>
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        /// <summary>
        /// Implement the IMiddleware logic
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // Handles the execption in the next step in pipeline
                await next(context);
            }
            catch (DbNoDataException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (DtoException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}