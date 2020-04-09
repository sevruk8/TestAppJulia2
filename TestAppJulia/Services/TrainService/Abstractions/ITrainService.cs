using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppJulia.Services.TrainService.Abstractions.Models;

namespace TestAppJulia.Services.TrainService.Abstractions
{
    interface ITrainService
    {
        TrainModel GetTrain(Guid id);

        List<TrainShortModel> GetAllTrains();

        void UpdateTrain(Guid trainId, TrainInfo train);

        Guid CreateTrain(TrainInfo train);

        void DeleteTrain(Guid id);
    }
}
