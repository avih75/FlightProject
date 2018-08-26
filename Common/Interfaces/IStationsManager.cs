using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IStationsManager
    {
        IEnumerable<StationModel> GetAll();
    }
}
