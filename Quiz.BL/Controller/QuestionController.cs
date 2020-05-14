using Quiz.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.BL.Controller
{
	public class QuestionController : ControllerBase
	{
		public List<Question> Questions { get; }

		public QuestionController()
		{
			Questions = GetQuestions();
		}

		private List<Question> GetQuestions()
		{
			return Read<Question>() ?? new List<Question>();
		}

		public void AddQuestion(string question, List<Answer> answers)
		{
			Questions.Add(new Question(question, answers));
			Save(Questions);
		}

		public Question SearchQuestionInFile(string queName)
		{
			if (string.IsNullOrWhiteSpace(queName))
			{
				throw new ArgumentNullException("Вопрос не может быть пустым", nameof(queName));
			}
			return Questions.SingleOrDefault(ans => ans.Name == queName);
		}

		public Question GetRandomQuestion()
		{
			Random random = new Random();
			return Questions[random.Next(0, Questions.Count)] ?? throw new NullReferenceException();
		}

	}
}
