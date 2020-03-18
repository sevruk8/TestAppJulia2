using System.Collections.Generic;
using Database.Database.Entities;
using TestAppJulia.Services.StationService.Abstractions.Models;

namespace TestAppJulia.Services.StationService.Abstractions
{
    public interface IStationService // CRUD - Create Read Update Delete
    {
        StationModel GetStation(int id);

        List<StationShortModel> GetAllStations();

        void UpdateStation(int stationId,StationInfo station);

        int CreateStation(StationInfo station);

        void DeleteStation(int id);
    }
}
