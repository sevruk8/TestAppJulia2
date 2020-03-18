using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Database.Entities
{
    public class Station
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<int> DirectionId { get; set; }

        public List<int> Employes { get; set; }
    }
}
