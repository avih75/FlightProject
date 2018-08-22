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

namespace Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var container = new Container();

            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //container.Register<IFlightsManager, FlightsManager>(Lifestyle.Scoped);
            //container.Register<IFlightsRepository, SqlFlightsRepository>(Lifestyle.Scoped);

            //var activator = new SimpleInjectorHubActivator(container);

            //GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => activator);

            

            //container.Verify();



            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
