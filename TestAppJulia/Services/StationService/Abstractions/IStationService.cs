using System;
using System.Collections.Generic;
using Database.Database.Entities;
using TestAppJulia.Services.StationService.Abstractions.Models;

namespace TestAppJulia.Services.StationService.Abstractions
{
    public interface IStationService // CRUD - Create Read Update Delete
    {
        StationModel GetStation(Guid id);

        List<StationShortModel> GetAllStations();

        void UpdateStation(Guid stationId, StationInfo station);

        Guid CreateStation(StationInfo station);

        void DeleteStation(Guid id);
    }
}
