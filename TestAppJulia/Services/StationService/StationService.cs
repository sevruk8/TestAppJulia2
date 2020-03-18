using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Database.Entities;
using Database.Database.Enums;
using TestAppJulia.Services.StationService.Abstractions;
using TestAppJulia.Services.StationService.Abstractions.Models;

namespace TestAppJulia.Services.StationService
{
    public class StationService : IStationService
    {
        private readonly DatabaseContext _dbContext;

        public StationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateStation(StationInfo stationInfo)
        {
            var station = new Station()
            {
                Id = (new Random()).Next(1, 1000),
                City = stationInfo.City,
                Name = stationInfo.Name,
                Employes = new List<int>(),
                DirectionId = new List<int>()
            };

            _dbContext.Stations.Add(station);
            _dbContext.SaveChanges();
            return station.Id;
        }

        public void DeleteStation(int id)
        {
            var station = _dbContext.Stations.First(e => e.Id == id);
            _dbContext.Stations.Remove(station);
            _dbContext.SaveChanges();
        }

        public List<StationShortModel> GetAllStations()
        {
            var stations = _dbContext.Stations;

            var resultStations = new List<StationShortModel>();

            foreach (var dbStation in stations)
            {
                var station = new StationShortModel()
                {
                    City = dbStation.City,
                    Name = dbStation.Name,
                    Id = dbStation.Id
                };
                resultStations.Add(station);
            }
                 
            return resultStations;
        }

        public StationModel GetStation(int id)
        {
            var dbStation = _dbContext.Stations.First(e => e.Id == id);

            var station = new StationModel()
            {
                City = dbStation.City,
                Name = dbStation.Name,
                Id = dbStation.Id,
                Employes = dbStation.Employes,
                DirectionId = dbStation.DirectionId
            };

            return station;
        }

        public void UpdateStation(int stationId,StationInfo stationInfo)
        {
            var station = _dbContext.Stations.First(e => e.Id == stationId);

            station.City = stationInfo.City;
            station.Name = stationInfo.Name;

            _dbContext.SaveChanges();
        }

        public void AddEmployee (int stationId,User user)
        {
            if (user.Type == UserType.StationUser)
            {
                var station = _dbContext.Stations.First(e => e.Id == stationId);

                station.Employes.Add(user.Id);

                _dbContext.SaveChanges();
            }
        }
    }
}
