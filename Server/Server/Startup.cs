using Microsoft.Owin;
using Owin;
using Server;

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