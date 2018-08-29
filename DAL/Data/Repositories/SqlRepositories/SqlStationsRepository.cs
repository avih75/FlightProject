using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Repositories.SqlRepositories
{
    class SqlStationsRepository : IStationsRepository
    {
        public void Add(StationModel station)
        {
            using (Context context = new Context())
            {
                context.Stations.Add(station);
                context.SaveChanges();
            }
        }

        public IEnumerable<StationModel> GetAll()
        {
            using (Context context = new Context())
            {
                return context.Stations.ToList();
            }
        }

        public StationModel GetStation(int stationId)
        {
            using (Context context = new Context())
            {
                return context.Stations.Find(stationId);
            }
        }

        public void Remove(int stationId)
        {
            using (Context context = new Context())
            {
                var station = context.Stations.Find(stationId);
                context.Stations.Add(station);
                context.SaveChanges();
            }
        }

        public void Update(StationModel station)
        {
            using (Context context = new Context())
            {
                context.Stations.Attach(station);
                context.Entry(station).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
