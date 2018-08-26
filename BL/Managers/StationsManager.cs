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

        private readonly IStationsWaitingsManager _stationsWaitingsManager;

        public StationsManager(IStationsRepository stationsRepository, IStationsWaitingsManager stationsWaitingsManager)
        {
            _stationsRepository = stationsRepository;
            _stationsWaitingsManager = stationsWaitingsManager;
        }

        public IEnumerable<StationModel> GetAll()
        {
            return _stationsRepository.GetAll();
        }
    }
}
