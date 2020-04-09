using Database;
using Database.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAppJulia.Services.TrainService.Abstractions;
using TestAppJulia.Services.TrainService.Abstractions.Models;

namespace TestAppJulia.Services.TrainService
{
    public class TrainService : ITrainService
    {
        private readonly DatabaseContext _dbContext;
        public TrainService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid CreateTrain(TrainInfo trainInfo)
        {
            var train = new Train()
            {
                Id = Guid.NewGuid(),
                Name = trainInfo.Name,
                Passagers = trainInfo.Passagers
            };

            _dbContext.Trains.Add(train);
            _dbContext.SaveChanges();
            return train.Id;
        }
        public void DeleteTrain(Guid id)
        {
            var train = _dbContext.Trains.First(e => e.Id == id);
            _dbContext.Trains.Remove(train);
            _dbContext.SaveChanges();
        }
        public List<TrainShortModel> GetAllTrains()
        {
            var trains = _dbContext.Trains;

            var resultTrains = new List<TrainShortModel>();

            foreach (var dbTrain in trains)
            {
                var train = new TrainShortModel()
                {
                    Name = dbTrain.Name,
                    Passagers = dbTrain.Passagers
                };
                resultTrains.Add(train);
            }

            return resultTrains;
        }
        public TrainModel GetTrain(Guid id)
        {
            var dbTrain = _dbContext.Trains.First(e => e.Id == id);

            var train = new TrainModel()
            {
                Id = dbTrain.Id,
                Name = dbTrain.Name,
                Passagers = dbTrain.Passagers
            };

            return train;
        }
        public void UpdateTrain(Guid trainId, TrainInfo trainInfo)
        {
            var train = _dbContext.Trains.First(e => e.Id == trainId);

            train.Name = trainInfo.Name;
            train.Passagers = trainInfo.Passagers;
            _dbContext.SaveChanges();
        }
    }
}
