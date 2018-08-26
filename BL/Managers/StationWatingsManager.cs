using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    public class StationWatingsManager: IStationsWaitingsManager
    {
        private ICollection<StationWaitingsModel> _stations;

        public StationWatingsManager()
        {
            _stations = new List<StationWaitingsModel>();
        }

        public void FillStationsCollection(IEnumerable<StationModel> stations)
        {
            foreach (var station in stations)
            {
                _stations.Add(new StationWaitingsModel(station.Id));
            }
        }

        public void AddStationToQueueOf(int waitingStationId, int queueStationId)
        {
            foreach (var myCollectionStation in _stations)
            {
                if (myCollectionStation.StationId == queueStationId)
                {
                    myCollectionStation.Add(waitingStationId);
                    break;
                }
            }
        }

        public int GetNextWaitingStationIdOf(int queueStationId)
        {
            int nextStationId = 0;

            foreach (var station in _stations)
            {
                if (station.StationId == queueStationId)
                {
                    nextStationId= station.GetNextStation();
                }
            }
            return nextStationId;
        }
    }
}
