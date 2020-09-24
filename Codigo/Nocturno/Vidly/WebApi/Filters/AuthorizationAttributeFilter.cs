using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface; 

namespace WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if(String.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Mandame un token papo"
                };
            }
            else
            {
                var sessions = this.GetSessionLogic(context);
                if(!sessions.IsCorrectToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "No tenes permisos mostro"
                    };
                }
            }
        }

        private ISessionLogic GetSessionLogic(AuthorizationFilterContext context)
        {
            var sessionType = typeof(ISessionLogic);

            return context.HttpContext.RequestServices.GetService(sessionType) as ISessionLogic;
        }
    }
}