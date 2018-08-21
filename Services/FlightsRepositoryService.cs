using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class FlightsRepositoryService
    {
        private readonly IFlightsRepository flightsRepository;

        public FlightsRepositoryService(IFlightsRepository flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public Tuple<bool,string> TryAddFlight(FlightModel flightModel)
        {
            string errorMessage = "";

            bool isSuccess = true;

            if()
        }
    }
}
