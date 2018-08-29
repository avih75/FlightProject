using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Args
{
    public class FlightEventArgs : EventArgs
    {
        public FlightEventArgs(FlightModel flight, int? stationId)
        {
            Flight = flight;
            StationId = stationId;
        }

        public FlightModel Flight { get; }

        public int? StationId { get; }
    }
}
