using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Database;
using Database.Database.Entities;
using Identity.Abstractions;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using TestAppJulia.Services.UserService.Abstractions;
using TestAppJulia.Services.UserService.Abstractions.Models;

namespace TestAppJulia.Services.UserService
{
    /// <summary>
    /// Класс реализующий интерфейс действий пользователя
    /// </summary>
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly ITokenAuthorization _tokenAuthorizationService;

        public UserService(DatabaseContext context, ITokenAuthorization tokenAuthorizationService)
        {
            _dbContext = context;
            _tokenAuthorizationService = tokenAuthorizationService;
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        public async Task<Token> Authorization(AuthorizationModel authorizationModel)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(x => x.UserLogin == authorizationModel.Login);
            if (existingUser != null)
            {
                if ((authorizationModel.Password + existingUser.PasswordSalt) == existingUser.PasswordHash)
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(authorizationModel.Login), new[] { new Claim("login", authorizationModel.Login), new Claim("email", existingUser.Email ?? string.Empty) });
                    var token = await _tokenAuthorizationService.GetToken(identity);
                    return token;
                }
                else
                {
                    throw new Exception("Неверный пароль");
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином не найден");
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public async Task Registration(RegistrationModel registrationModel)
        {
            var salt = Convert.ToString(Guid.NewGuid());
            User user = new User
            {
                UserLogin = registrationModel.Login,
                Email = registrationModel.Email,
                Name = registrationModel.Name,
                LastName = registrationModel.LastName,
                Type = registrationModel.Type,
                PasswordSalt = salt,
                PasswordHash = (registrationModel.Password + salt)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Guid CreateUser(UserInfo userInfo)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userInfo.Name,
                LastName = userInfo.LastName,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(Guid id)
        {
            var user = _dbContext.Users.First(e => e.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public List<UserShortModel> GetAllUsers()
        {
            var users = _dbContext.Users;

            var resultUsers = new List<UserShortModel>();

            foreach (var dbUser in users)
            {
                var user = new UserShortModel()
                {
                    Name = dbUser.Name,
                    LastName = dbUser.LastName,
                    Id = dbUser.Id
                };
                resultUsers.Add(user);
            }

            return resultUsers;
        }

        public UserModel GetUser(Guid id)
        {
            var dbUser = _dbContext.Users.First(e => e.Id == id);

            var user = new UserModel()
            {
                Name = dbUser.Name,
                LastName = dbUser.LastName,
                Id = dbUser.Id,

            };

            return user;
        }

        public void UpdateUser(Guid Id, UserInfo userInfo)
        {
            var user = _dbContext.Users.First(e => e.Id == Id);

            user.Name = userInfo.Name;
            user.LastName = userInfo.LastName;

            _dbContext.SaveChanges();
        }


    }
}
