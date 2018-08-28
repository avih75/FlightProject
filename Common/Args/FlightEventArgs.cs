using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Args
{
    public class FlightEventArgs : EventArgs
    {
        private readonly FlightModel _flight;
        private readonly int? _stationId;

        public FlightEventArgs(FlightModel flight, int? stationId)
        {
            _flight = flight;
            _stationId = stationId;
        }
    }
}
