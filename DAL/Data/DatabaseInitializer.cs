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
            StationModel station1 = new StationModel();
            StationModel station2 = new StationModel();
            StationModel station3 = new StationModel();
            StationModel station4 = new StationModel();
            StationModel station5 = new StationModel();

            
        }
    }
}
