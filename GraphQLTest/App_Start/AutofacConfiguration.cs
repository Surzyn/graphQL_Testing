using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using GameData;
using GraphQL.Types;
using GraphQLTest.Controllers;
using GraphQLTest.Helpers;
using PlayerData.Providers;

namespace GraphQLTest.App_Start
{
    public class AutofacConfiguration
    {
        public static void Register(HttpConfiguration config)
        {
            Create(config);
        }

        public static IContainer Create(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PlayerData.Providers.PlayerData>().As< IPlayerData>();
            builder.RegisterType<GameDataProvider>().As<IGameDataProvider>();

            //builder.Register((x, o) =>
            //{
            //    return new GameTestSchema(t => x.Resolve(t) as IGraphType );
            //});

            builder.RegisterApiControllers(typeof (GraphQLController).Assembly);
            var container = builder.Build();

            //builder.RegisterType<GameTestSchema>(t => container.Resolve(t)).SingleInstance();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}