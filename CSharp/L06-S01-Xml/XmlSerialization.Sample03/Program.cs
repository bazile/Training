using System;
using System.Xml.Serialization;

namespace XmlSamples.Sample03
{
	public class Person
	{
		public string FirstName;
		public string MiddleInitial;
		public string LastName;

		//[NonSerialized]
		public string PlaceOfBirth;

		private int _age = 420;
	}

	class Program
	{
		static void Main(string[] args)
		{
			Person p = new Person {FirstName = "Duncan", MiddleInitial = "?", LastName = "MacLeod", PlaceOfBirth = "Glenfinnan, Scotland"};
			//Person p = new Person();
			//p.FirstName = "Jeff";
			//p.MiddleInitial = "A";
			//p.LastName = "Price";
			//p.PlaceOfBirth = "Glenfinnan, Scotland";

			XmlSerializer xmlSerializer = new XmlSerializer(p.GetType());
			xmlSerializer.Serialize(Console.Out, p);
			Console.WriteLine();
		}
	}
}
