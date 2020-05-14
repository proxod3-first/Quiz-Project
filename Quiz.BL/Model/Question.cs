using System;
using System.Collections.Generic;

namespace Quiz.BL.Model
{
	/// <summary>
	/// Вопрос.
	/// </summary>
	[Serializable]
	public class Question
	{
		#region Свойства
		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Ответы на вопрос.
		/// </summary>
		public List<Answer> Answers { get; }
		#endregion

		/// <summary>
		/// Создать новый вопрос.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="number"></param>
		public Question(string name, List<Answer> answers)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("Вопрос не может быть пустым", nameof(name));
			Name = name;
			Answers = answers ?? new List<Answer>();
		}

		public override string ToString()
		{
			return "-" + Name;
		}
	}
}
