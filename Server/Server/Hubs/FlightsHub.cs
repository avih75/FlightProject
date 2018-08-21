using System;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Server.Models;

namespace Server.Hubs
{
    [HubName("FlightsHub")]
    public class FlightsHub : Hub, ICaller
    {
        private event OnGetInEventHandler OnGetInEventHandler;

        public FlightModel GetIn(bool isLanding)
        {
            FlightModel flight = OnGetInEventHandler.Invoke(isLanding);
            return flight;
        }

        public void RegisterGetInEvent(OnGetInEventHandler onGetIn)
        {
            OnGetInEventHandler += onGetIn;
        }

    }
}