using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using Server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Server.Controllers
{
    public class FlightsController : ApiController
    {
        private readonly IFlightsManager _flightsManager;

        private readonly ICaller _caller;

        private readonly IHubContext _hub;

        public FlightsController(IFlightsManager flightsManager, ICaller caller)
        {
            _flightsManager = flightsManager;
            _caller = caller;
            _hub = GlobalHost.ConnectionManager.GetHubContext<FlightsHub>();

            _flightsManager.RegisterToTimerEvent(OnTimerEvent);
            _caller.RegisterGetInEvent(OnGetIn);
        }
        [HttpPost]
        [ResponseType(typeof(FlightModel))]
        public IHttpActionResult Add(FlightModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _flightsManager.AddFlight(flight);
            return CreatedAtRoute("DefaultApi", new { id = flight.ID }, flight);
        }

        private FlightModel OnGetIn(bool isLanding)
        {
            return _flightsManager.GetFlight(isLanding);
        }


        private void OnTimerEvent(FlightModel flightModel)
        {
            _hub.Clients.All.TimerEvent(flightModel);
        }
    }
}
