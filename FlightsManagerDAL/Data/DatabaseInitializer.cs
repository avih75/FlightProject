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
            base.Seed(context);
        }
    }
}
