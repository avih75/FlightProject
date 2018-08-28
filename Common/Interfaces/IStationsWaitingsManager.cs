using Common.Args;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public delegate void FlightEnterEventHandler(FlightEventArgs args);
    public interface IStationsWaitingsManager
    {
        void AddNewFlight(FlightModel flight);

        void RegisterToFlightEvent(FlightEnterEventHandler onFlightEvent);
    }
}
