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
            ActiveStationModel station1 = new ActiveStationModel();
            ActiveStationModel station2 = new ActiveStationModel();
            ActiveStationModel station3 = new ActiveStationModel();
            ActiveStationModel station4 = new ActiveStationModel();
            ActiveStationModel station5 = new ActiveStationModel();

            
        }
    }
}
