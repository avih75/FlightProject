using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FlightsManagerDAL.Data.Repositories
{
    public class SqlFlightsRepository : IFlightsRepository
    {
        public void Add(FlightModel flight)
        {
            using(Context context = new Context())
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }
        }

        public IEnumerable<FlightModel> GetAll()
        {
            using (Context context = new Context())
            {
                var flights = context.Flights.ToList();
                context.SaveChanges();

                return flights;
            }
        }

        public FlightModel GetFlight(int flightId)
        {
           using(Context context = new Context())
            {
                return context.Flights.Find(flightId);
            }
        }

        public void Remove(int flightId)
        {
            using (Context context = new Context())
            {
                FlightModel flight = context.Flights.Find(flightId);
                context.Flights.Remove(flight);
                context.SaveChanges();
            }
        }

        public void Update(FlightModel flight)
        {
            using(Context context = new Context())
            {
                context.Flights.Attach(flight);
                context.Entry(flight).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
