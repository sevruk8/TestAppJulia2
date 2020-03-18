
using System.Collections.Generic;
using TestAppJulia.Services.PassageService.Abstractions.Models;

namespace TestAppJulia.Services.PassageService.Abstractions
{
    public interface IPassageService
    {
        PassageModel GetPassage(int id);

        List<PassageShortModel> GetAllPassages();

        void UpdatePassage(int passageId, PassageInfo passage);

        int CreatePassage(PassageInfo passage);

        void DeletePassage(int id);
    }
}
