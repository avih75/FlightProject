using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Common.Data
{
    public class Context: DbContext
    {
        public DbSet<PlainModel> Plains { get; set; }
        public DbSet<FlightModel> Flights { get; set; }
        public Context(): base("Context")
        {

        }
    }
}
