using System;
using System.Web;
using System.Web.Mvc;
using TwitterClient.Core.Services.User;
using TwitterClient.Web.Infrastructure.DI;

namespace TwitterClient.Web.Infrastructure
{
    public class MyAuthModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += SetCurrentUser;
            context.EndRequest += StoreCurrentUser;
        }

        private void StoreCurrentUser(object sender, EventArgs eventArgs)
        {
            var userService = DependencyResolver.Current.GetService<IUserService>();
            if (userService.IsAuthenticated)
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("user", userService.GetCurrentUser().Id));
            }

        }

        private void SetCurrentUser(object sender, EventArgs eventArgs)
        {
            var userService = DependencyResolver.Current.GetService<IUserService>();
            var userId = HttpContext.Current.Request.Cookies["user"]?.Value;
            if (userId != null)
            {
                userService.SetCurrentUser(userId);
            }
        }

        public void Dispose()
        {
        }
    }
}