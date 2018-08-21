using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Common.Interfaces
{
    public delegate void TimerElapsedEventHandler(int id);

    public interface IFlightsTimeManager
    {
        event TimerElapsedEventHandler TimerEventHandler;

        void TakeOff();

        void Add(FlightTimeModel flightTimeModel);

        int GetFirstId();
    }
}
