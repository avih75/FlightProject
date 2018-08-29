using Common.Enums;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class BaseStationModel
    {
        public bool IsStartingStation { get; set; }

        public bool IsLastStation { get; set; }

        public StripEnum Strip { get; set; }

        public int StationID { get; set; }

        public bool IsOccupied { get; set; }

        public int? FlightId { get; set; }

        public FlightModel Flight { get; set; }

        public List<BaseStationModel> NextDepartureStations { get; set; }

        public List<BaseStationModel> NextLandingStations { get; set; }

        public List<IStationClient> WaitingStations { get; set; }

        public BaseStationModel()
        {
            NextDepartureStations = new List<BaseStationModel>();

            NextLandingStations = new List<BaseStationModel>();

            WaitingStations = new List<IStationClient>();

        }

        public virtual void AddStation(IStationClient station)
        {

        }
        public virtual void EvacuateStation()
        {

        }

        public virtual void RegisterFlightEvent()
        {

        }
    }
}
