using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationsWaitingsManager
    {
        void FillStationsCollection(IEnumerable<StationModel> stations);

        void AddStationToQueueOf(int waitingStationId, int queueStationId);

        int GetNextWaitingStationIdOf(int queueStationId);
    }
}
