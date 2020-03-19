using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppJulia.Services.TrainService.Abstractions.Models;

namespace TestAppJulia.Services.TrainService.Abstractions
{
    interface ITrainService
    {
        TrainModel GetTrain(int id);

        List<TrainShortModel> GetAllTrains();

        void UpdateTrain(int trainId, TrainInfo train);

        int CreateTrain(TrainInfo train);

        void DeleteTrain(int id);
    }
}
