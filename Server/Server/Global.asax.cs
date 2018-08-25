using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Common.Interfaces;
using Server.Activators;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DAL.Data.Repositories;
using BL.Managers;

namespace Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IFlightsRepository, SqlFlightsRepository>(Lifestyle.Scoped);
            container.Register<IFlightsManager, FlightsManager>(Lifestyle.Scoped);
            container.Register<IFlightsTimeManager, FlightsTimeManager>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);



            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
