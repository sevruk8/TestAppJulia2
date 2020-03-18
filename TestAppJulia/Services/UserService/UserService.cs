using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Database.Entities;
using TestAppJulia.Services.UserService.Abstractions;
using TestAppJulia.Services.UserService.Abstractions.Models;

namespace TestAppJulia.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUser(UserInfo userInfo)
        {
            var user = new User()
            {
                Id = (new Random()).Next(1, 1000),
                Name = userInfo.Name,
                LastName = userInfo.LastName,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int id)
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

        public UserModel GetUser(int id)
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

        public void UpdateUser(int userId, UserInfo userInfo)
        {
            var user = _dbContext.Users.First(e => e.Id == userId);

            user.Name = userInfo.Name;
            user.LastName = userInfo.LastName;

            _dbContext.SaveChanges();
        }


    }
}
