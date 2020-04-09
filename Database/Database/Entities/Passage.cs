using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Database.Entities
{
    public class Passage
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<int> IdTrain { get; set; }
        public string Passager { get; set; }
        
    }
}
