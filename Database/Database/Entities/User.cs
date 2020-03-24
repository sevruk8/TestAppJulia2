using System;
using System.Collections.Generic;
using System.Text;
using Database.Database.Enums;

namespace Database.Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserLogin { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public UserType Type { get; set; } 

    }
}
