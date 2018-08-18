using Common.Managers;
using Common.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlightCreator
{
    class Program
    {
        static Models.FlightFactoryModel factoryFlight;
        static Timer timer;
        static SignalRConnectionManager signalRConnectionManager;
        static void Main(string[] args)
        {
            signalRConnectionManager = new SignalRConnectionManager();
            signalRConnectionManager.StartConnection();
            factoryFlight = new Models.FlightFactoryModel();
            timer = new Timer
            {
                Interval = 5000
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.Read();
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            FlightModel newFlight = factoryFlight.CreateFlight();
            Console.WriteLine(newFlight.ToString());
            // Api Call To Server Send New Flight
            signalRConnectionManager.Invoke("Recive", newFlight);
        }
    }
}
