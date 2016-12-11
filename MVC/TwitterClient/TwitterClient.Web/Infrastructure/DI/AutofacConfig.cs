using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using TwitterClient.Core.Services.Twitter;
using TwitterClient.Core.Services.User;
using TwitterClient.DataAccess.ExternalServices;
using TwitterClient.Entity.Setting;

namespace TwitterClient.Web.Infrastructure.DI
{
    public class AutofacConfig
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TwitterSettings>();
            builder.RegisterType<TwitterProxy>().As<ITwitterProxy>();
            builder.RegisterType<TwitterService>().As<ITwitterService>();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            _container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}