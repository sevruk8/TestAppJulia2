using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Database.Entities
{
    public class Station
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<int> DirectionId { get; set; }

        public List<Guid> Employes { get; set; }
    }
}
