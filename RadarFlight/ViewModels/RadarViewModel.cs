using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RadarFlight.ViewModels
{
    public class RadarViewModel
    {
        //List<ActiveStationModel> StationsList { get; set; }
        //List<FlightModel> FlightList { get; set; }
        //FirstStationModel startStationProp {get;set;notify();}

        public ICommand StartTheRadarClick;

        public RadarViewModel()
        {
            GetHubConection();
            CommandInit();
        }

        private void CommandInit()
        {
            //StartTheRadarClick = new ICommand(MakeFirstStateCall);
        }

        private void GetHubConection()
        {
            // get the contact to the hub
        }

        //private void MakeFirstStateCall()
        //{
        //    //if (connection)
        //    {
        //        // get the station list
        //        // get the second list
        //        GenerateView();
        //    }
        //}

        //private void GenerateView()
        //{
        //    int MaxStartStation;// = bigest base list count
        //    int LongestPath;// =  biggest path form base to end of two ways
        //    //Canvas pathsCanvas = CreatCanvasForView(LongestPath, MaxStartStation);
        //    FillCanvas(pathsCanvas);
        //    PutFlights();
        //}

        //private Grid CreatCanvasForView(int x, int y)
        //{
        //    // generate grid whit coloms and rows by the sizes
        //}

        //private void FillCanvas(Canvas pathsCanvas)
        //{
        //    foreach (var item in collection)
        //    {
        //        // put the base station A
        //        // and wallk the all paths and put station
        //    }

        //    foreach (var item in collection)
        //    {
        //        // put the base station B
        //    }
        //}

        //private void PutFlights()
        //{
        //    foreach (var item in collection)
        //    {
        //        // put all flights
        //    }
        //}

        private void MakeMove()
        {
            // make move of flight picture to the new station
            // update Dictionery Flights
        }
    }
}
