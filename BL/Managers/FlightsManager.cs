﻿using Common.Args;
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

        private readonly IStationsManager _stationsManager;

        private event TimerEventHandler _timerEventHandler;

        
        public FlightsManager(IFlightsRepository flightsRepository, IFlightsTimeManager departureFlightsManager, IFlightsTimeManager landingFlightsRepository, IStationsManager stationsManager)
        {
            _flightsRepository = flightsRepository;
            _departureFlightsTimeManager = departureFlightsManager;
            _landingFlightsTimeManager = landingFlightsRepository;
            _stationsManager = stationsManager;

            _departureFlightsTimeManager.TimerEventHandler += OnTimerEvent;
            _landingFlightsTimeManager.TimerEventHandler += OnTimerEvent;
            _stationsManager.RegisterToFlightEvent(OnFlightEnterEvent);
        }

        private void OnFlightEnterEvent(FlightEventArgs args)
        {
            //updating queues
            //notify client
            //updating repository
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

            _stationsManager.FlightTimeArrivedEvent(flight);
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
