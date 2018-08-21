using System;

namespace Common.Models
{
    public class FlightModel
    {

        public int ID { get; set; }

        public int PlainId { get; set; }

        public bool IsDeparture { get; set; }

        public string FlightName { get; set; }

        public DateTime Time { get; set; }

        public PlainModel Plain { get; set; }

        public override string ToString()
        {
            return string.Format($"Name : {FlightName }  plain : {Plain.Name}  Date : {Time}  isDeparture : {IsDeparture}");
        }
    }
}
