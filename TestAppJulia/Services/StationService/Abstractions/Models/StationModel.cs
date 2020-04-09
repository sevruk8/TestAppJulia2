using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.StationService.Abstractions.Models
{
    public class StationModel
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<int> DirectionId { get; set; }

        public List<Guid> Employes { get; set; }
    }
}
