using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;

namespace WebApi.Filters
{
    public class AuthorizationDIFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessionsLogic;
        public AuthorizationDIFilter(ISessionLogic sessions)
        {
            this.sessionsLogic = sessions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Pone un Authorization vieja"
                };
            }
            else
            {
                if(!this.sessionsLogic.IsCorrectToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Nono, sin permisos no pasas"
                    };
                }
            }
        }
    }
}