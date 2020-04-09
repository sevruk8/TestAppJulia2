
using System;
using System.Collections.Generic;
using TestAppJulia.Services.PassageService.Abstractions.Models;

namespace TestAppJulia.Services.PassageService.Abstractions
{
    public interface IPassageService
    {
        PassageModel GetPassage(Guid id);

        List<PassageShortModel> GetAllPassages();

        void UpdatePassage(Guid passageId, PassageInfo passage);

        Guid CreatePassage(PassageInfo passage);

        void DeletePassage(Guid id);
    }
}
