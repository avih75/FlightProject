using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class StationModel
    {
        public int Id { get; set; }

        public bool IsOccupied { get; set; }

        public int? PlainId { get; set; }

        public PlainModel Plain { get; set; }

        public ICollection<StationModel> NextDepartureStations { get; set; }

        public ICollection<StationModel> NextLandingStations { get; set; }

        public ICollection<StationModel> WaitingStations { get; set; }


        public StationModel()
        {
            NextDepartureStations = new List<StationModel>();

            NextLandingStations = new List<StationModel>();

            WaitingStations = new List<StationModel>();
        }
    }
}
