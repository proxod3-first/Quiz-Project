using Quiz.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
		#region Свойства
		public List<User> Users { get; }

        public User CurrentUser { get; private set; }

        public bool IsNewUser { get; }
		#endregion

		public UserController(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == name);
            if (CurrentUser == null)
            {
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Read<User>() ?? new List<User>();
        }

        public void SetNewUserData(string name, DateTime birthDate)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            }
            if (birthDate < DateTime.Parse("01.01.1950") || birthDate >= DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Неправильный формат даты рождения", nameof(birthDate));
            }

            CurrentUser = new User(name, birthDate);
            Users.Add(CurrentUser);
            Save(Users);
        }

    }
}
