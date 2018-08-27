using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Models
{
    public class StationManager : IStationModel
    {
        List<IStationModel> baseDepartureStations;
        List<IStationModel> baseLandStations;
        List<IStationModel> mainList;
        readonly int stationQuantity;

        public StationManager(int stationsNumber, string arivePaths, string DeparturePaths)
        {   // the string should show the paths option   " 1/2,3,5,6/8,9 " example
            stationQuantity = stationsNumber;
            InstallStation(arivePaths, DeparturePaths);
        }


        private async void InstallStation(string arivePaths, string DeparturePaths)
        {
            // create the station (emptys)
            mainList = new List<IStationModel>();
            for (int i = 0; i < stationQuantity; i++)
            {
                mainList.Add(new ActiveStationModel());
            }

            for (int i = 0; i < stationQuantity; i++)
            {
                List<int> nextDepartureStation = GetNextLists(i, DeparturePaths);
                List<int> nextAriveStation = GetNextLists(i, arivePaths);
                await PowerOnStation(i, nextDepartureStation, nextAriveStation);
            }
            baseDepartureStations = CreateIstationList(new List<int> { 0, 2 });
            baseLandStations = CreateIstationList(new List<int> { 6 });
        }

        private List<int> GetNextLists(int i, string departurePaths)
        {
            throw new NotImplementedException();
        }

        private List<IStationModel> CreateIstationList(List<int> stationsList)
        {
            List<IStationModel> temp = new List<IStationModel>();
            foreach (int index in stationsList)
            {
                temp.Add(mainList[index]);
            }
            return temp;
        }
        private Task PowerOnStation(int id, List<int> land, List<int> departure)
        {
            List<IStationModel> lendTemp = CreateIstationList(land);
            List<IStationModel> departureTemp = CreateIstationList(departure);
            mainList[id].TurnOnStation(lendTemp, departureTemp, id + 1);
            return null;
        }
        private void GetNewListed(FlightModel newListed)
        {
            IStationModel nextStation;
            if (newListed.IsDeparture)
            {
                nextStation = GetShorterWatingListStation(baseDepartureStations);
            }
            else
            {
                nextStation = GetShorterWatingListStation(baseDepartureStations);
            }
            nextStation.AddToWaitingLis(this);
        }
        private IStationModel GetShorterWatingListStation(List<IStationModel> stationList)
        {
            IStationModel stationToListedTo = stationList[0];
            int ListSize = stationToListedTo.ListSize();
            for (int i = 1; i < stationList.Count; i++)
            {
                if (ListSize < stationList[i].ListSize())
                {
                    stationToListedTo = stationList[i];
                    ListSize = stationToListedTo.ListSize();
                }
            }
            return stationToListedTo;
        }

        public FlightModel FlightInStation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void SendFlightToNextStation(FlightModel flight)
        {
            // send to the server message to step in the specific flight
        }
        public int ListSize()
        {
            return int.MaxValue;
        }
        public void AddToWaitingLis(IStationModel station)
        {
            throw new NotImplementedException();
        }
        public void TurnOnStation(List<IStationModel> landList, List<IStationModel> departList, int id)
        {
            throw new NotImplementedException();
        }
    }
}

