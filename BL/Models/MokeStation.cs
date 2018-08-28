using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MokeStation : IStationClient
    {
        List<FlightModel> Flights { get; set; }

        public MokeStation(List<FlightModel> flights, FlightModel flight)
        {
            Flights = flights;
            Flight = flight;
            FlightId = flight.ID;
        }

        public int? FlightId { get; set; }
        public FlightModel Flight { get; set; }

        public void EvacuateStation()
        {
            Flights.Remove(Flight);
            FlightId = null;
            Flight = null;
        }
    }
}
