using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class StationsController : ApiController
    {
        private readonly IStationsManager _stationsManager;

        public StationsController(IStationsManager stationsManager)
        {
            _stationManager = stationsManager;
        }

        public IEnumerable<StationModel> Get()
        {
            return _stationsManager.GetAll();
        }
    }
}
