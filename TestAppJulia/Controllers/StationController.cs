using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestAppJulia.Services.StationService;
using TestAppJulia.Services.StationService.Abstractions.Models;

namespace TestAppJulia.Controllers
{
    [Route("Stations")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly StationService _stationService;

        public StationController(StationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public ActionResult<List<StationShortModel>> GetStations()
        {
            return _stationService.GetAllStations();
        }

        [HttpGet("{id}")]
        public ActionResult<StationModel> GetStation([FromRoute]Guid id)
        {
            return _stationService.GetStation(id);
        }

        [HttpPost]
        public ActionResult<Guid> CreateStation([FromBody]StationInfo station)
        {
           return _stationService.CreateStation(station);
        }

        [HttpDelete]
        public void DeleteStation([FromQuery] Guid id)
        {
            _stationService.DeleteStation(id);
        }

        [HttpPut("{stationId}")]
        public void UpdateStation([FromBody] StationInfo station, [FromRoute]Guid stationId)
        {
            _stationService.UpdateStation(stationId,station);
        }
    }
}
