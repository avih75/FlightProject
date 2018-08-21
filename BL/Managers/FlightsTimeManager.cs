using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace BL.Managers
{
    public class FlightsTimeManager : IFlightsTimeManager
    {
        public event TimerElapsedEventHandler TimerEventHandler;

        private LinkedList<FlightTimeModel> _flightTimeModels;

        private object _lockObject;

        private Timer _timer;

        private FlightTimeModel First
        {
            get
            {
                return _flightTimeModels.First.Value;
            }
        }
        

        public FlightsTimeManager()
        {
            SetManagerFields();
        }

        

        private void SetManagerFields()
        {
            _flightTimeModels = new LinkedList<FlightTimeModel>();

            _lockObject = new object();
        }

        public void Add(FlightTimeModel flightTimeModel)
        {
            lock (_lockObject)
            {
                if (IsFirstOrEarlier(flightTimeModel))
                {
                    _flightTimeModels.AddFirst(flightTimeModel);

                    StartTimer();
                }
                else
                {
                    var tmp = _flightTimeModels.First;
                    while (NextNodeIsntNullOrEarlier(flightTimeModel, tmp))
                    {
                        tmp = tmp.Next;
                    }
                    _flightTimeModels.AddAfter(tmp, flightTimeModel);
                }
            }
        }

        private void StartTimer()
        {
            SetTimer();

            _timer.Start();
        }

        private void SetTimer()
        {
            _timer = new Timer();

            _timer.Elapsed += TimerElapsed;

            _timer.AutoReset = false;

            TimeSpan interval = First.DateTime - DateTime.Now;

            if (interval.TotalSeconds <= 0)
            {
                interval = new TimeSpan(0, 0, 1);
            }
            _timer.Interval = interval.TotalSeconds;
        }



        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (_lockObject)
            {
                _timer.Stop();
                _timer.Dispose();

                int id = First.Id;
                TimerEventHandler.Invoke(id);
            }
        }

        public void TakeOff()
        {
            lock (_lockObject)
            {
                _flightTimeModels.Remove(First);
                if (First != null)
                {
                    StartTimer();
                }
            }
        }



        private static bool NextNodeIsntNullOrEarlier(FlightTimeModel flightTimeModel, LinkedListNode<FlightTimeModel> node)
        {
            return node.Next != null || node.Next.Value.CompareTo(flightTimeModel) < 0;
        }

        private bool IsFirstOrEarlier(FlightTimeModel flightTimeModel)
        {
            return _flightTimeModels.First == null || First.CompareTo(flightTimeModel) > 0;
        }

        public int GetFirstId()
        {
            return First.Id;
        }

        
    }
}
