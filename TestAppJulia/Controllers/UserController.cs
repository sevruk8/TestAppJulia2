using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestAppJulia.Services.UserService;
using TestAppJulia.Services.UserService.Abstractions.Models;

namespace TestAppJulia.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserShortModel>> GetUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser([FromRoute]int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public ActionResult<int> CreateUser([FromBody]UserInfo user)
        {
            return _userService.CreateUser(user);
        }

        [HttpDelete]
        public void DeleteUser([FromQuery] int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPut("{userId}")]
        public void UpdateUser([FromBody] UserInfo user, [FromRoute]int userId)
        {
            _userService.UpdateUser(userId, user);
        }
    }
}
