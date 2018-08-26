using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class StationWaitingsModel
    {
        public int StationId { get; set; }
        public Queue<int> WaitingStationsIds { get; set; }

        public StationWaitingsModel(int stationId)
        {
            StationId = stationId;
            WaitingStationsIds = new Queue<int>();
        }

        public void Add(int waitingStationId)
        {
            WaitingStationsIds.Enqueue(waitingStationId);
        }

        public int GetNextStation()
        {
            return WaitingStationsIds.Dequeue();
        }
    }
}
