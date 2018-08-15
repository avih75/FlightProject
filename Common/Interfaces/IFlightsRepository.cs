using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IFlightsRepository
    {
        IEnumerable<FlightModel> GetAll();

        FlightModel GetFlight(int flightId);

        void Add(FlightModel flight);

        void Update(FlightModel flight);

        void Remove(int flightId);
    }
}
