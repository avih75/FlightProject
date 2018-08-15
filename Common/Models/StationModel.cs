using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class StationModel : IStationModel
    {
        public int StationId { get; set; }

        public FlightModel FlightInStation { get; set; }

        public void SendFlightToNextStation()
        {
            IsOccupied = false;
            FlightInStation = null;
            TakeNextFlightRequest();
            // action of movment in the server
        }

        public int ListSize()
        {
            return StationWaitingList.Count;
        }

        public void AddToWaitingLis(IStationModel station)
        {
            StationWaitingList.Enqueue(station);
            if (IsOccupied != true)
                TakeNextFlightRequest();
        }

        public void TurnOnStation(List<IStationModel> landList, List<IStationModel> departList, int id)
        {
            StationId = id;
            NextTakeOffStations = departList;
            NextLandingStations = landList;
            while (true) ;
        }

        private bool IsOccupied { get; set; }

        private IStationModel curentHandler;

        private List<IStationModel> NextTakeOffStations { get; set; }

        private List<IStationModel> NextLandingStations { get; set; }

        private Queue<IStationModel> StationWaitingList { get; set; }

        private void TakeNextFlightRequest()
        {
            if (StationWaitingList.Count > 0)
            {
                curentHandler = StationWaitingList.Dequeue();
                IsOccupied = true;
                // handel the flight - frezz for timer
                if (curentHandler.FlightInStation.IsDeparture)
                    AskToMoveNextStation(NextTakeOffStations);
                else
                    AskToMoveNextStation(NextLandingStations);
            }
        }

        private void AskToMoveNextStation(List<IStationModel> handleredList)
        {
            int x = handleredList[0].ListSize();
            int index = 0;
            for (int i = 1; i < handleredList.Count; i++)
            {
                if (x > handleredList[i].ListSize())
                {
                    x = handleredList[i].ListSize();
                    index = i;
                }
            }
            handleredList[index].AddToWaitingLis(this);
        }
    }
}
