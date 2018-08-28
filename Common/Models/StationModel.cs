﻿using Common.Args;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Common.Models
{
    public delegate void FlightEventHandler(FlightEventArgs args);

    public class StationModel : BaseStationModel, IStationClient
    {
        private event FlightEventHandler _flightEvent;

        private readonly Timer timer;

        public StationModel()
        {
            timer = new Timer();
            timer.Elapsed += FlightTimeEnded;
        }

        private void FlightTimeEnded(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            if (IsLastStation)
            {
                EvacuateStation();
            }
            BaseStationModel nextStation;
            if (Flight.IsDeparture)
            {
                nextStation = GetBestStation(NextDepartureStations);
            }
            else
            {
                nextStation = GetBestStation(NextLandingStations);
            }
            nextStation.AddStation(this);
        }

        private BaseStationModel GetBestStation(ICollection<BaseStationModel> nextStations)
        {
            // find the station with the shortest q
            int min = int.MaxValue;
            BaseStationModel stationToReturn = null;
            foreach (BaseStationModel station in nextStations)
            {
                if (station.WaitingStations.Count < min)
                    stationToReturn = station;
            }
            return stationToReturn;
        }

        public override void EvacuateStation()
        {
            OnFlightMoveEvent();
            Flight = null;
            FlightId = null;
            if (WaitingStations.Count > 0)
                CallNextFlight();
        }

        public override void AddStation(IStationClient station)
        {
            WaitingStations.Add(station);
            if (Flight == null)
                CallNextFlight();
        }

        public void RegisterFlightEvent(FlightEventHandler flightEvent)
        {
            _flightEvent += flightEvent;
        }

        private void CallNextFlight()
        {
            if (WaitingStations.Count > 0)
            {
                Random rnd = new Random();
                var nextStation = WaitingStations[0];
                WaitingStations.Remove(nextStation);
                Flight = nextStation.Flight;
                FlightId = nextStation.FlightId;
                OnFlightMoveEvent();
                nextStation.EvacuateStation();
                timer.Interval = rnd.Next(1000, 5000);
                timer.Start();
            }
        }

        private void OnFlightMoveEvent()
        {
            FlightEventArgs arg;
            if (IsLastStation)
                arg = new FlightEventArgs(Flight, null);
            else
                arg = new FlightEventArgs(Flight, StationID);

            _flightEvent.Invoke(arg);
        }
    }
}
