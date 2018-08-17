using Microsoft.AspNet.SignalR.Hubs;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Activators
{
    public class SimpleInjectorHubActivator
    {
        private readonly Container _container;

        public SimpleInjectorHubActivator(Container container)
        {
            _container = container;
        }

        public IHub CreateHub(HubDescriptor hubDescriptor)
        {
            return (IHub)_container.GetInstance(hubDescriptor.HubType);
        }
    }
}