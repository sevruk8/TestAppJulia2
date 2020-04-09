using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppJulia.Services.UserService.Abstractions.Models;

namespace TestAppJulia.Services.UserService.Abstractions
{
    interface IUserService
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        Task Registration(RegistrationModel registrationModel);

        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        Task<Token> Authorization(AuthorizationModel authorizationModel);

        // CRUD - Create Read Update Delete
        UserModel GetUser(Guid id);

        List<UserShortModel> GetAllUsers();

        void UpdateUser(Guid userId, UserInfo user);

        Guid CreateUser(UserInfo user);

        void DeleteUser(Guid id);
    }
}
