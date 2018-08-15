using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCreator
{
    class Program
    {
        static Models.FlightFactoryModel factoryFlight;
        static System.Timers.Timer timer;
        static void Main(string[] args)
        {
            factoryFlight = new Models.FlightFactoryModel();
            timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.Read();
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FlightModel newFlight = factoryFlight.CreateFlight();
            Console.WriteLine(newFlight.ToString());
            // Api Call To Server Send New Flight
        }
    }
}
