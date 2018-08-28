using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationsManager
    {
        IEnumerable<BaseStationModel> GetAll();

        void FlightTimeArrivedEvent(FlightModel flight);

        void RegisterToFlightEvent(FlightEnterEventHandler flightEnterEvent);
    }
}
