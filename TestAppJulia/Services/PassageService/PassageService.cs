using Database;
using Database.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAppJulia.Services.PassageService.Abstractions;
using TestAppJulia.Services.PassageService.Abstractions.Models;

namespace TestAppJulia.Services.PassageService
{
    public class PassageService : IPassageService
    {
        private readonly DatabaseContext _dbContext;
        public PassageService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid CreatePassage(PassageInfo passageInfo)
        {
            var passage = new Passage()
            {
                Id = Guid.NewGuid(),
                From = passageInfo.From,
                To = passageInfo.To,
                Passager = passageInfo.Passager,
                IdTrain = new List<int>()
            };

            _dbContext.Passages.Add(passage);
            _dbContext.SaveChanges();
            return passage.Id;
        }
        public void DeletePassage(Guid id)
        {
            var passage = _dbContext.Passages.First(e => e.Id == id);
            _dbContext.Passages.Remove(passage);
            _dbContext.SaveChanges();
        }
        public List<PassageShortModel> GetAllPassages()
        {
            var passages = _dbContext.Passages;

            var resultPassages = new List<PassageShortModel>();

            foreach (var dbPassage in passages)
            {
                var passage = new PassageShortModel()
                {
                    From = dbPassage.From,
                    To = dbPassage.To,
                    Id = dbPassage.Id
                };
                resultPassages.Add(passage);
            }

            return resultPassages;
        }
        public PassageModel GetPassage(Guid id)
        {
            var dbPassage = _dbContext.Passages.First(e => e.Id == id);

            var passage = new PassageModel()
            {
                From = dbPassage.From,
                To = dbPassage.To,
                Id = dbPassage.Id,
                Passager = dbPassage.Passager,
                IdTrain = dbPassage.IdTrain
            };

            return passage;
        }
        public void UpdatePassage(Guid passageId, PassageInfo passageInfo)
        {
            var passage = _dbContext.Passages.First(e => e.Id == passageId);

            passage.From = passageInfo.From;
            passage.To = passageInfo.To;
            passage.Passager = passageInfo.Passager;
            _dbContext.SaveChanges();
        }
    }
}