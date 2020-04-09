using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppJulia.Services.UserService.Abstractions.Models
{
    /// <summary>
    /// Модель регистрации
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Тип пользователя: пассажир, работник станции или работник поезда 
        /// </summary>
        public UserType Type { get; set; }

    }
}
