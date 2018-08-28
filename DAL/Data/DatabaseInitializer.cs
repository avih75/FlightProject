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
            BaseStationModel station1 = new BaseStationModel
            {
                Strip = StripEnum.AirStrip
            };

            BaseStationModel station2 = new BaseStationModel
            {
                Strip = StripEnum.LandingStrip
            };

           BaseStationModel station3 = new BaseStationModel
           {
               Strip = StripEnum.AirStrip
           };

            BaseStationModel station4 = new BaseStationModel
            {
                Strip = StripEnum.LandingStrip
            };

            BaseStationModel station5 = new BaseStationModel
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
