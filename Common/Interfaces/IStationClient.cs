using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationClient
    {
        void EvacuateStation();
        int? FlightId { get; set; }
        FlightModel Flight { get; set; }
    }
}
