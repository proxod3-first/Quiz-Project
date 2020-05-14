using System;

namespace Quiz.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            Name = name;
        }
        public User(string name, DateTime birthDate) : this(name)
        {
            if (birthDate < DateTime.Parse("01.01.1950") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Неверный формат даты рождения", nameof(birthDate));
            }

            BirthDate = birthDate;
        }

        public User() { }

        public override string ToString()
        {
            return Name + "; " + Age + " (лет)";
        }
    }
}
