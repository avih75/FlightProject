using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    
    public class FlightsManager : IFlightsManager
    {
        private readonly IFlightsRepository _flightsRepository;

        private readonly IFlightsTimeManager _departureFlightsManager;

        private readonly IFlightsTimeManager _landingFlightsManager;

        private event TimerEventHandler _timerEventHandler;

        
        public FlightsManager(IFlightsRepository flightsRepository, IFlightsTimeManager departureFlightsManager, IFlightsTimeManager landingFlightsRepository)
        {
            _flightsRepository = flightsRepository;
            _departureFlightsManager = departureFlightsManager;
            _landingFlightsManager = landingFlightsRepository;
            RegisterGetInEvent();
        }


        private void RegisterGetInEvent()
        {
            _departureFlightsManager.TimerEventHandler += OnTimerEvent;
            _landingFlightsManager.TimerEventHandler += OnTimerEvent;
        }


        public void AddFlight(FlightModel flight)
        {
            _flightsRepository.Add(flight);

            FlightTimeModel timeModel = new FlightTimeModel(flight.ID, flight.Time);
            if (flight.IsDeparture)
            {
                _departureFlightsManager.Add(timeModel);
            }
            else
            {
                _landingFlightsManager.Add(timeModel);
            }

        }

        private void OnTimerEvent(int id)
        {
            FlightModel flight = _flightsRepository.GetFlight(id);
            _timerEventHandler.Invoke(flight);
        }

        public void RegisterToTimerEvent(TimerEventHandler onTimerElapsed)
        {
            _timerEventHandler += onTimerElapsed;
        }

        public FlightModel GetFlight(bool isLanding)
        {
            int flightId = 0;

            if (isLanding)
            {
                flightId = _landingFlightsManager.GetFirstId();
                _landingFlightsManager.TakeOff();
            }
            else
            {
                flightId = _departureFlightsManager.GetFirstId();
                _departureFlightsManager.TakeOff();
            }
            
            return _flightsRepository.GetFlight(flightId);
        }

       
    }
}
