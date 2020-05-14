using System.Collections.Generic;

namespace Quiz.BL.Controller
{
	public abstract class ControllerBase
	{
		private readonly SerializableClass manager = new SerializableClass();

		protected void Save<T>(List<T> items) where T : class
		{
			manager.Save(items);
		}
		protected List<T> Read<T>() where T : class
		{
			return manager.Read<T>();
		}
	}
}
