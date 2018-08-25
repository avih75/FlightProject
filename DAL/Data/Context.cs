using Common.Models;
using FlightsManagerDAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.Data
{
    public class Context: DbContext
    {
        public DbSet<PlainModel> Plains { get; set; }
        public DbSet<FlightModel> Flights { get; set; }
        public DbSet<StationModel> Stations { get; set; }

        public Context(): base("ConnectionString")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
