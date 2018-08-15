using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCreator.Interfaces
{
    public interface IFlightFactory
    {
        FlightModel CreateFlight();
    }
}
