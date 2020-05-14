using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Quiz.BL.Controller
{
	class SerializableClass
	{

		public List<T> Read<T>() where T : class
		{
			var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
			string fileName = typeof(T).Name;

			using (var file = new FileStream(fileName + ".json", FileMode.OpenOrCreate))
			{
				if (file.Length > 0 && jsonFormatter.ReadObject(file) is List<T> items)
					return items;
				else
					return new List<T>();
			}
		}

		public void Save<T>(List<T> items) where T : class
		{
			var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
			var fileName = typeof(T).Name;

			using (var file = new FileStream(fileName + ".json", FileMode.Create))
			{
				jsonFormatter.WriteObject(file, items);
			}
		}

	}
}
