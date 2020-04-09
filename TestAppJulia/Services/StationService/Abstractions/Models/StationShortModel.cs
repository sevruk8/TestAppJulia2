using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.StationService.Abstractions.Models
{
    public class StationShortModel
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
    }
}
