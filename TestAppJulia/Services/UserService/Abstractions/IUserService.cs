using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppJulia.Services.UserService.Abstractions.Models;

namespace TestAppJulia.Services.UserService.Abstractions
{
    interface IUserService// CRUD - Create Read Update Delete
    {
        UserModel GetUser(int id);

        List<UserShortModel> GetAllUsers();

        void UpdateUser(int userId, UserInfo user);

        int CreateUser(UserInfo user);

        void DeleteUser(int id);
    }
}
