using System;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Server.Models;

namespace Server.Hubs
{
    [HubName("FlightsHub")]
    public class FlightsHub : Hub
    {

    }
}