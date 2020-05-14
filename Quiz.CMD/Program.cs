using Quiz.BL.Controller;
using Quiz.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Quiz.CMD
{
	class Program
	{
		static void Main()
		{

			CultureInfo culture = CultureInfo.CurrentCulture; // or .CreateSpecificCulture("YOUR_CULTURE");
			ResourceManager resourceManager = new ResourceManager("Quiz.CMD.Languages.Messanges", typeof(Program).Assembly);

			Console.WriteLine("\t" + resourceManager.GetString("Welcome", culture));

			Console.Write(resourceManager.GetString("Enter_User", culture));
			string userName = StringNullCheck();

			var userController = new UserController(userName);
			if (userController.IsNewUser)
			{
				Console.WriteLine(resourceManager.GetString("NewUser", culture));

				DateTime birthDate = BirthDateTryParse();
				userController.SetNewUserData(userName, birthDate);
			}
			Console.WriteLine($"\nYour data: {userController.CurrentUser}\n");

			var questionController = new QuestionController();
			while (true)
			{
				Console.WriteLine("\nA - Add a question \nR - Random question \nS - Search a question \nQ - quit");
				var choiceTask = Console.ReadKey();
				Console.WriteLine();
				Console.WriteLine();

				switch (choiceTask.Key)
				{
					case ConsoleKey.A:
						var (question, answers) = MakeQuestion();
						questionController.AddQuestion(question, answers);
						Console.WriteLine("The question successfully added!\n");
						break;
					case ConsoleKey.R:
						if (questionController.Questions.Count > 0)
						{
							var que = questionController.GetRandomQuestion();
							DisplayQuestion(que);
						}
						break;
					case ConsoleKey.S:
						string queName = QuestionChech();
						var searchQue = questionController.SearchQuestionInFile(queName);
						if (searchQue == null)
						{
							Console.WriteLine("Question not found\n");
							break;
						}
						DisplayQuestion(searchQue);
						break;
					case ConsoleKey.Q:
						Console.WriteLine("Come back!)\n");
						Console.ReadLine();
						return;  // Return
					default:
						Console.WriteLine("Not found!");
						break;
				}
				Console.ReadLine();
				Console.Clear();
			}// End While

		}// End Main

		private static void DisplayQuestion(Question question)
		{
			Console.WriteLine("\n" + question + "\n");

			foreach (var item in question.Answers)
				Console.WriteLine(item);

			Console.WriteLine("Your answer: ");
			int yourAns = IntTryParse();
			Console.WriteLine();

			Answer checkAns = question.Answers.SingleOrDefault(ans => ans.IsCorrectAnswer && ans.Number == yourAns);
			if (checkAns != null)
				Console.WriteLine("You are Right)");
			else
				Console.WriteLine("You are Not Right)");
		}

		private static (string question, List<Answer> answers) MakeQuestion()
		{
			return (question: QuestionChech(), answers: MakeAnswers());
		}

		private static List<Answer> MakeAnswers()
		{
			string s_entered_answer = ""; int n = 1;
			List<Answer> enteredAnswers = new List<Answer>();

			Console.WriteLine("Enter the Answers to the Questions (q - exit): ");
			while (true)
			{
				Console.Write(n + ". ");
				s_entered_answer = Console.ReadLine();

				if (s_entered_answer == "q" || s_entered_answer == "Q")
				{
					Console.Write("\nCorrect answer: ");
					int i_CorrectAns = IntTryParse();
					if (i_CorrectAns <= enteredAnswers.Count && i_CorrectAns > 0)
					{
						enteredAnswers.Find(ans => ans.Number == i_CorrectAns).IsCorrectAnswer = true;
						return enteredAnswers;
					}
					else
					{
						Console.WriteLine("There is no such answer\n");
					}
				}
				else if (!string.IsNullOrWhiteSpace(s_entered_answer))
				{
					enteredAnswers.Add(new Answer(s_entered_answer, n, false));
					n++;
				}
				else
					Console.WriteLine("The Answer is incorrect\n");
			}

		}

		private static string QuestionChech()
		{
			Console.Write("\nEnter your question: ");
			string question;
			while (true)
			{
				question = Console.ReadLine();
				if (question.Contains("?"))
					return question;
				else
					Console.WriteLine("Again\n");
			}
		}

		private static string StringNullCheck()
		{
			string str;
			while (true)
			{
				str = Console.ReadLine();
				if (!string.IsNullOrWhiteSpace(str))
					return str;
				else
					Console.WriteLine("Again!\n");
			}
		}

		private static int IntTryParse()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int result))
				{
					return result;
				}
				else
				{
					Console.WriteLine("Again.\n");
				}
			}
		}

		private static DateTime BirthDateTryParse()
		{
			while (true)
			{
				Console.WriteLine("Birthday: ");
				if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
				{
					return result;
				}
				else
				{
					Console.WriteLine("Wrong format of birthday\n");
				}
			}
		}

	}
}
