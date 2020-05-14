using System;

namespace Quiz.BL.Model
{
	/// <summary>
	/// Ответ.
	/// </summary>
	public class Answer
	{
		#region Свойства
		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номер.
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Верный ли ответ?
		/// </summary>
		public bool IsCorrectAnswer { get; set; }
		#endregion

		public Answer() { }

		/// <summary>
		/// Создать новый ответ.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="number"></param>
		/// <param name="isCorrectAnswer"></param>
		public Answer(string name, int number, bool isCorrectAnswer)
		{
			#region Input verification
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Вопрос не может быть пустым", nameof(name));
			}

			if (!bool.TryParse(isCorrectAnswer.ToString(), out bool _))
			{
				throw new ArgumentNullException("Верный ответ имеет неправильный формат", nameof(isCorrectAnswer));
			}
			#endregion

			Name = name;
			Number = number;
			IsCorrectAnswer = isCorrectAnswer;
		}

		public override string ToString()
		{
			return Number + ". " + Name;
		}

	}
}
