using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Managers
{
    public class StationsManager : IStationsManager
    {
        private readonly IStationsRepository _stationsRepository;

        public StationsManager(IStationsRepository stationsRepository)
        {
            _stationsRepository = stationsRepository;
        }
        public IEnumerable<StationModel> GetAll()
        {
            return _stationsRepository.GetAll();
        }
    }
}
