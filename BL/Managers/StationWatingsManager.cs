using BL.Models;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    public class StationWatingsManager
    {
        List<StationModel> baseDepartureStations;
        List<StationModel> baseLandStations;

        List<FlightModel> LandingFlights;
        List<FlightModel> DepartureFlight;

        readonly int stationQuantity;

        public StationWatingsManager(IStationsRepository stationsRepository)
        {
            baseLandStations = new List<StationModel>();
            baseDepartureStations = new List<StationModel>();
            GenerateStations(stationsRepository);
        }

        private void GenerateStations(IStationsRepository stationsRepository)
        {
            var stations = stationsRepository.GetAll();
            foreach (var station in stations)
            {
                if (station.IsStartingStation)
                {
                    switch (station.Strip)
                    {
                        case StripEnum.AirStrip:
                            baseDepartureStations.Add(station);
                            break;
                        case StripEnum.LandingStrip:
                            baseLandStations.Add(station);
                            break;
                        default:
                            baseDepartureStations.Add(station);
                            baseLandStations.Add(station);
                            break;
                    }
                }
            }
        }

        public void AddNewFlight(FlightModel flight)
        {
            if (flight.IsDeparture)
                DepartureFlight.Add(flight);
            else
                LandingFlights.Add(flight);
            MoveToBase(flight);
        }

        private void MoveToBase(FlightModel flight)
        {
            MokeStation newMoke;
            StationModel nextStation;
            if (flight.IsDeparture)
            {
                newMoke = new MokeStation(DepartureFlight, flight);
                nextStation = GetShorterWatingListStation(baseDepartureStations);
            }
            else
            {
                newMoke = new MokeStation(LandingFlights, flight);
                nextStation = GetShorterWatingListStation(baseLandStations);
            }
            nextStation.AddStation(newMoke);
        }

        private StationModel GetShorterWatingListStation(List<StationModel> stationList)
        {
            StationModel stationToReturn = null;
            int min = int.MaxValue;
            foreach (var station in stationList)
            {
                if (station.WaitingStations.Count < min)
                {
                    stationToReturn = station;
                    min = station.WaitingStations.Count;
                }
            }
            return stationToReturn;
        }

    }
}
