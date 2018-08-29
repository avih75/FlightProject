
using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlightCreator
{
    class Program
    {
        const string apiUrl = "http://localhost:54780/";
        private static readonly HttpClient client = new HttpClient();
        static Models.FlightFactoryModel factoryFlight;
        static Timer timer;

        static void Main(string[] args)
        {
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
            var jsonObject = JsonConvert.SerializeObject(newFlight);
            var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
            client.PostAsync(apiUrl, stringContent);
        }
    }
}
