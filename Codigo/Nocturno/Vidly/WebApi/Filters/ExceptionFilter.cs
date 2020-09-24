using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch(Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Problemas del servidor, que se le va hacer?"
                };
            }
        }
    }
}