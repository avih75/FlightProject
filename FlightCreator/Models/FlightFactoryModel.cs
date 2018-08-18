using Common.Models;
using FlightCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCreator.Models
{
    public class FlightFactoryModel : IFlightFactory
    {
        Random rnd = new Random();

        public FlightModel CreateFlight()
        {
            string flightName = GetName();
            PlainModel plain = GetNewPlain();
            bool isDeparture = GetIsDeparture();
            DateTime planedTime = GetPlanedTime();
            return new FlightModel()
            {
                FlightName = flightName,
                IsDeparture = isDeparture,
                Plain = plain,
                Time = planedTime
            };

        }

        private PlainModel GetNewPlain()
        {
            char firstLatter = (char)rnd.Next(65, 90);
            char secondLatter = (char)rnd.Next(65, 90);
            string number = rnd.Next(100, 999).ToString();
            PlainModel newPlain = new PlainModel()
            {
                Name = firstLatter + secondLatter + number,
                Sits = rnd.Next(150, 1000)
            };
            return newPlain;
        }

        private DateTime GetPlanedTime()
        {
            TimeSpan timeSpan = new TimeSpan(0,0,rnd.Next(20, 60));
            return DateTime.Now + timeSpan;
        }

        private bool GetIsDeparture()
        {
            int way = rnd.Next(0, 2);
            if (way == 0)
                return true;
            else
                return false;
        }

        private string GetName()
        {
            char firstLatter = (char)rnd.Next(65, 90);
            char secondLatter = (char)rnd.Next(65, 90);
            string number = rnd.Next(100, 999).ToString();
            return firstLatter + secondLatter + number;
        }
    }
}
