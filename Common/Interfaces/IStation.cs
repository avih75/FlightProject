using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationModel
    {
        FlightModel FlightInStation { get; set; }
        int ListSize();
        void AddToWaitingLis(IStationModel station);
        void TurnOnStation(List<IStationModel> landList, List<IStationModel> departList, int id);
        void SendFlightToNextStation(FlightModel flight);
    }
}
