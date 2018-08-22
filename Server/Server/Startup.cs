using BL.Managers;
using DAL.Data.Repositories;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Server;
using Server.Hubs;

namespace Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}