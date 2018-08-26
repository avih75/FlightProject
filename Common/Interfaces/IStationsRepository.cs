using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationsRepository
    {
        StationModel GetStation(int stationId);

        IEnumerable<StationModel> GetAll();

        void Add(StationModel station);

        void Remove(int stationId);

        void Update(StationModel station);
    }
}
