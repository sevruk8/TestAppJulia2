﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.UserService.Abstractions.Models
{
    public class UserShortModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
