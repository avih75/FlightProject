using System;

namespace Common.Models
{
    public class FlightModel
    {
        //private Random rnd = new Random();
        // true - is outgoing  // false - is incoming

        public int ID { get; set; }

        public int PlainId { get; set; }

        public bool IsDeparture { get; set; }

        public string FlightName { get; set; }

        public DateTime Time { get; set; }

        //public TimeSpan NededTimeInStation()
        //{
        //    return new TimeSpan(rnd.Next(0, 5000));
        //}

        public PlainModel Plain { get; set; }

        public override string ToString()
        {
            return string.Format($"Name : {FlightName }  plain : {Plain.Name}  Date : {Time}  isDeparture : {IsDeparture}");
        }
    }
}
