using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.UserService.Abstractions.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public UserType Type { get; set; }

    }
}
