using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestAppJulia.Services.TrainService;
using TestAppJulia.Services.TrainService.Abstractions.Models;

namespace TestAppJulia.Controllers
{
    [Route("Trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly TrainService _trainService;

        public TrainController(TrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public ActionResult<List<TrainShortModel>> GetTrains()
        {
            return _trainService.GetAllTrains();
        }

        [HttpGet("{id}")]
        public ActionResult<TrainModel> GetTrain([FromRoute]Guid id)
        {
            return _trainService.GetTrain(id);
        }

        [HttpPost]
        public ActionResult<Guid> CreateTrain([FromBody]TrainInfo train)
        {
            return _trainService.CreateTrain(train);
        }

        [HttpDelete]
        public void DeleteTrain([FromQuery] Guid id)
        {
            _trainService.DeleteTrain(id);
        }

        [HttpPut("{trainId}")]
        public void UpdateTrain([FromBody] TrainInfo train, [FromRoute]Guid trainId)
        {
            _trainService.UpdateTrain(trainId, train);
        }
    }
}
