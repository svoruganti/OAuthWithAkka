using System.Reflection;
using System.Web.Http;
using Akka.Actor;
using Akka.DI.AutoFac;
using Autofac;
using Autofac.Integration.WebApi;
using OAuthWithAkka.Actors;
using OAuthWithAkka.Web.Handlers;

namespace OAuthWithAkka.Web
{
    public static class AutofacConfig
    {
        public static void RegisterContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            var actorSystem = ActorSystem.Create("OAuthActorSystem");
            builder.RegisterInstance(actorSystem).As<ActorSystem>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterHandlers(builder);

            var container = builder.Build();
            new AutoFacDependencyResolver(container, actorSystem);
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<RequestActorHandler>().As<IRequestActorHandler>().SingleInstance();
            builder.RegisterType<RequestActor>();
        }
    }
}