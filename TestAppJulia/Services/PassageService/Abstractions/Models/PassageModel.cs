﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.PassageService.Abstractions.Models
{
    public class PassageModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<int> IdTrain { get; set; }
        public string Passager { get; set; }
        public Guid Id { get; set; }
    }
}
