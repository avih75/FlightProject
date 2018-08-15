using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class StationModel : IStation
    {
        public int StationId { get; set; }

        private bool IsOccupied { get; set; }

        public FlightModel FlightInStation { get; set; }

        private List<StationModel> NextTakeOffStations { get; set; }

        private List<StationModel> NextLandingStations { get; set; }

        private LinkedList<StationModel> StationWaitingList { get; set; }

        public void SendFlightToNextStation()
        {
            IsOccupied = false;
            FlightInStation = null;
            TakeNextFlightRequest();
            // action of movment in the server
        }

        private void TakeNextFlightRequest()
        {
            throw new NotImplementedException();
        }
    }
}
