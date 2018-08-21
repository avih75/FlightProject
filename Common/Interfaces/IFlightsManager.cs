using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace Common.Interfaces
{
    public delegate void TimerEventHandler(FlightModel flight);
    public interface IFlightsManager
    {
        void AddFlight(FlightModel flight);

        void RegisterToTimerEvent(TimerEventHandler onTimerElapsed);
        FlightModel GetFlight(bool isLanding);
    }
}
