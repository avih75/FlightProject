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

        private readonly IHubContext _hub;

        public FlightsController(IFlightsManager flightsManager, ICaller caller)
        {
            _flightsManager = flightsManager;
            _hub = GlobalHost.ConnectionManager.GetHubContext<FlightsHub>();

            _flightsManager.RegisterToTimerEvent(OnTimerEvent);
        }

        [HttpPost]
        [ResponseType(typeof(FlightModel))]
        public IHttpActionResult AddFlight(FlightModel flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _flightsManager.AddFlight(flight);
            return CreatedAtRoute("DefaultApi", new { id = flight.ID }, flight);
        }

        [HttpGet]
        [ResponseType(typeof(FlightModel))]
        public IHttpActionResult GetFlight(bool isLanding)
        {
            var flight = _flightsManager.GetFlight(isLanding);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        private void OnTimerEvent(FlightModel flightModel)
        {
            _hub.Clients.All.TimerEvent(flightModel);
        }
    }
}
