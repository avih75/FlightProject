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

        private readonly IFlightsTimeManager _departureFlightsTimeManager;

        private readonly IFlightsTimeManager _landingFlightsTimeManager;

        private event TimerEventHandler _timerEventHandler;

        
        public FlightsManager(IFlightsRepository flightsRepository, IFlightsTimeManager departureFlightsManager, IFlightsTimeManager landingFlightsRepository)
        {
            _flightsRepository = flightsRepository;
            _departureFlightsTimeManager = departureFlightsManager;
            _landingFlightsTimeManager = landingFlightsRepository;

            _departureFlightsTimeManager.TimerEventHandler += OnTimerEvent;
            _landingFlightsTimeManager.TimerEventHandler += OnTimerEvent;
        }
        

        public void AddFlight(FlightModel flight)
        {
            _flightsRepository.Add(flight);

            FlightTimeModel timeModel = new FlightTimeModel(flight.ID, flight.Time);
            if (flight.IsDeparture)
            {
                _departureFlightsTimeManager.Add(timeModel);
            }
            else
            {
                _landingFlightsTimeManager.Add(timeModel);
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
                flightId = _landingFlightsTimeManager.GetFirstId();
                _landingFlightsTimeManager.TakeOff();
            }
            else
            {
                flightId = _departureFlightsTimeManager.GetFirstId();
                _departureFlightsTimeManager.TakeOff();
            }
            
            return _flightsRepository.GetFlight(flightId);
        }

       
    }
}
