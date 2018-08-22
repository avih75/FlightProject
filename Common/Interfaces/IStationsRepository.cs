using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationsRepository
    {
        ActiveStationModel GetStation(int stationId);

        IEnumerable<ActiveStationModel> GetAll();

        void Add(ActiveStationModel station);

        void Remove(int StationId);

        void Update(ActiveStationModel station);
    }
}
