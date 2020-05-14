using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Quiz.BL.Controller.Tests
{
	[TestClass()]
	public class UserControllerTests
	{
		[TestMethod()]
		public void SetNewUserDataTest()
		{
			// Arrange
			string name = Guid.NewGuid().ToString();
			DateTime dateTime = DateTime.Now.AddDays(-15);
			var newUser = new UserController(name);


			// Act
			newUser.SetNewUserData(name, dateTime);


			// Assert
			Assert.AreEqual(name, newUser.CurrentUser.Name);
		}


	}
}