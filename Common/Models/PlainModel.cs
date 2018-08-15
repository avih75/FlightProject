using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class PlainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sits { get; set; }
        public ICollection<FlightModel> Flights { get; set; }

        public PlainModel()
        {
            Flights = new List<FlightModel>();
        }
    }
}
