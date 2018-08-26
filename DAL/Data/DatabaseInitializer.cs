using Common.Enums;
using Common.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace FlightsManagerDAL.Data
{
    public class DatabaseInitializer: DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            StationModel station1 = new StationModel
            {
                Strip = StripEnum.AirStrip
            };

            StationModel station2 = new StationModel
            {
                Strip = StripEnum.LandingStrip
            };

           StationModel station3 = new StationModel
           {
               Strip = StripEnum.AirStrip
           };

            StationModel station4 = new StationModel
            {
                Strip = StripEnum.LandingStrip
            };

            StationModel station5 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip
            };

            station1.NextDepartureStations.Add(station5);
            station1.NextLandingStations.Add(station5);

            station2.NextDepartureStations.Add(station5);
            station2.NextLandingStations.Add(station5);

            station5.NextDepartureStations.Add(station3);
            station5.NextLandingStations.Add(station3);
        }
    }
}
