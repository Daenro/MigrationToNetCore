using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TwitterClient.Core.Services.User;

namespace TwitterClient.Web.Infrastructure
{
    public class MyAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public MyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var userId = context.Request.Cookies["user"];
            if (userId != null)
            {
                userService.SetCurrentUser(userId);
            }

            await _next.Invoke(context);

            if (userService.IsAuthenticated)
            {
                context.Response.Cookies.Append("user", userService.GetCurrentUser().Id);
            }
        }
    }
}