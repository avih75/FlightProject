using System;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Server.Interfaces;
using Server.Models;

namespace Server.Hubs
{
    [HubName("FlightsHub")]
    public class FlightsHub : Hub
    {
        private readonly IFlightsRepository _flightsRepository;

        private readonly IFlightsManager _departureFlightsManager;

        private readonly IFlightsManager _landingFlightsManager;

        public FlightsHub(IFlightsRepository flightsRepository, IFlightsManager departureFlightsManager, IFlightsManager landingFlightsManager)
        {
            _flightsRepository = flightsRepository;

            _departureFlightsManager = departureFlightsManager;

            _landingFlightsManager = landingFlightsManager;

            _departureFlightsManager.TimerEventHandler += RequestToEnter;

            _landingFlightsManager.TimerEventHandler += RequestToEnter;
        }

        public void Recive(FlightModel flight)
        {
            _flightsRepository.Add(flight);

            if (flight.IsDeparture)
            {
                ReciveFlight(_departureFlightsManager, flight);
            }
            else
            {
                ReciveFlight(_landingFlightsManager, flight);
            }
        }

        private void ReciveFlight(IFlightsManager flightsManager, FlightModel flight)
        {
            flightsManager.Add(new FlightTimeModel(flight.ID,flight.Time));
        }

        private void RequestToEnter(int id)
        {
            FlightModel flight = _flightsRepository.GetFlight(id);
            Clients.All.RequestToEnter(flight);
        }

        public void TakeOff(bool isLanding)
        {
            if (isLanding)
            {
                TakeOff(_landingFlightsManager);
            }
            else
            {
                TakeOff(_departureFlightsManager);
            }

        }

        private void TakeOff(IFlightsManager flightsManager)
        {
            int flightId = flightsManager.GetFirstId();
            FlightModel flight = _flightsRepository.GetFlight(flightId);
            Clients.All.TakeOff(flight);
            flightsManager.TakeOff();
        }


    }
}