using Server.Managers;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Server.Interfaces
{
    public interface IFlightsManager
    {

        event TimerElapsedEventHandler TimerEventHandler;

        void TakeOff();

        void Add(FlightTimeModel flightTimeModel);

        int GetFirstId();
    }
}
