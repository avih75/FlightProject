using Common.Models;
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
        private List<StationModel> StationsList { get; set; }

        public List<FlightModel> FlightList { get; set; }

        public RadarViewModel(Grid inMotion)
        {
            CreatFakeDataBase();
            GetHubConection();
            GetDataToShow();

        }

        private void CreatFakeDataBase()
        {
            StationsList = new List<StationModel>();

            FlightList = new List<FlightModel>();
            FlightList.Add(new FlightModel()
            {
                FlightName = "AVI",
                ID = 1,
                IsDeparture = true,
                Time = DateTime.Now
            });
            FlightList.Add(new FlightModel()
            {
                FlightName = "Eli",
                ID = 2,
                IsDeparture = false,
                Time = DateTime.Now
            });
        }

        private void GetHubConection()
        {
            // get the contact to the hub
            // sing to get change for flight and call make move
        }

        private void GetDataToShow()
        {
            //make get http request for flight lisdt
            // make get http request for stationlist

        }

        private void GenerateGrid()
        {
            int MaxStartStation = 0;// = bigest base list count
            int LongestPath = 0;// =  biggest path form base to end of two ways
            Canvas pathsCanvas = CreatCanvasForView(LongestPath, MaxStartStation);
            FillCanvas(pathsCanvas);
            PutFlights();
        }

        private Canvas CreatCanvasForView(int longestPath, int maxStartStation)
        {
            return null;
        }

        private void FillCanvas(Canvas pathsCanvas)
        {
            //foreach (var item in collection)
            //{
            //    // put the base station A
            //    // and wallk the all paths and put station
            //}

            //foreach (var item in collection)
            //{
            //    // put the base station B
            //}
        }

        private void PutFlights()
        {
            //foreach (var item in collection)
            //{
            //    // put all flights
            //}
        }

        private void MakeMove(FlightModel flight, int stationId)
        {
            //
            // make move of flight picture to the new station
            // update Dictionery Flights
        }
    }
}
