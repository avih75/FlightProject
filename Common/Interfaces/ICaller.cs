using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public delegate FlightModel OnGetInEventHandler(bool isLanding);

    public interface ICaller
    {
        FlightModel GetIn(bool isLanding);

        void RegisterGetInEvent(OnGetInEventHandler onGetIn);
    }
}
