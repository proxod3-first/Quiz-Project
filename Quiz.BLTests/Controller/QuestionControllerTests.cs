using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.BL.Controller.Tests
{
	[TestClass()]
	public class QuestionControllerTests
	{
		[TestMethod()]
		public void AddQuestionTest()
		{
			// Arrange
			string name = Guid.NewGuid().ToString();
			Random random = new Random();
			int num = random.Next(0, 10);
			List<Answer> ans = new List<Answer>();
			ans.Add(new Answer(name, num, false));
			QuestionController controller = new QuestionController();


			// Act
			controller.AddQuestion(name, ans);


			// Assert
			Assert.AreEqual(name, controller.Questions.First(que => que.Name == name).Name);
		}

		[TestMethod()]
		public void SearchQuestionInFileTest()
		{
			// Arrange
			string name = Guid.NewGuid().ToString();
			QuestionController controller = new QuestionController();


			// Act
			var que = controller.SearchQuestionInFile(name);
			if (que == null)
				return;


			// Assert
			Assert.AreEqual(name, que.Name);

		}
	}
}