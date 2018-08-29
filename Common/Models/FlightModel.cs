using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Models
{
    public class FlightModel
    {
        Random rnd = new Random();

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

        public async Task StartOperation()
        {
            Thread.Sleep(rnd.Next(1000, 5000));
        }
    }
}
