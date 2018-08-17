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
        private static StationManager manager;
        public static StationManager GetManager()
        {
            if (manager == null)
                manager = new StationManager();
            return manager;
        }

        List<IStationModel> baseDepartureStations;
        List<IStationModel> baseLandStations;
        List<IStationModel> mainList;
        readonly int stationQuantity = 7;


        private StationManager()
        {
            InstallStation();
            CreateHubConectionToServer();
        }
        private void CreateHubConectionToServer()
        {
            // throw new NotImplementedException();
        }
        private async void InstallStation()
        {
            mainList = new List<IStationModel>();
            for (int i = 0; i < stationQuantity; i++)
            {
                mainList.Add(new StationModel());
            }
            for (int i = 0; i < stationQuantity; i++)
            {
                await PowerOnStation(i, new List<int> { }, new List<int> { });
            }
            baseDepartureStations = CreateIstationList(new List<int> { 0, 2 });
            baseLandStations = CreateIstationList(new List<int> { 6 });
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

