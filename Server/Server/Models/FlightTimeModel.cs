using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class FlightTimeModel: IComparable<FlightTimeModel>
    {
        public int Id { get;  }

        public DateTime DateTime { get; set; }

        public FlightTimeModel(int id, DateTime dateTime)
        {
            Id = id;
            DateTime = dateTime;
        }

        public int CompareTo(FlightTimeModel other)
        {
            return DateTime.Compare(DateTime, other.DateTime);
        }

        public void UpdateTime(TimeSpan timeSpan)
        {
            DateTime.Add(timeSpan);
        }
    }
}