using Common.Data.SqlRepositories;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Server;
using Server.Hubs;
using Server.Managers;

namespace Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
        typeof(FlightsHub),
        () => new FlightsHub(new SqlFlightsRepository(), new FlightsTimeManager(), new FlightsTimeManager()));

            app.MapSignalR();
        }
    }
}