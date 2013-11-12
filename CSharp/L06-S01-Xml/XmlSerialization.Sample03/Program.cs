using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlSamples.Sample03
{
	public class Person
	{
        // XML сериализация умеет работать только с public полями/свойствами
		public string FirstName;
		public string LastName;

        //[XmlIgnore]
		public string PlaceOfBirth;
        
        // private поля не участвуют в XML сериализации
		private int _age;

        public void SetAge(int age)
        {
            _age = age;
        }

	    public override string ToString()
	    {
	        return string.Format("{0} {1} from {2}. Age={3}", FirstName, LastName, PlaceOfBirth, _age);
	    }
	}

	class Program
	{
		static void Main()
		{
			Person duncanMacLeod = new Person {FirstName = "Duncan", LastName = "MacLeod", PlaceOfBirth = "Glenfinnan, Scotland"};
            duncanMacLeod.SetAge(420);
            Console.WriteLine(duncanMacLeod);

            // Будем выполнять сериализацию в MemoryStream чтобы не создавать временный файл
            MemoryStream memStream = new MemoryStream();

            // Создаем экземпляр XmlSerializer для выполнения сериализации и десериализации
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            // Сериализуем значение переменной duncanMacLeod
            xmlSerializer.Serialize(memStream, duncanMacLeod);

            // Читаем данные из потока чтобы увидеть результат сериализации
		    memStream.Position = 0;
            StreamReader reader = new StreamReader(memStream);
		    string xmlResult = reader.ReadToEnd();
            Console.WriteLine("[--------------------------------------------------]");
		    Console.WriteLine(xmlResult);
            Console.WriteLine("[--------------------------------------------------]");

            // Десериализуем данные из потока
		    memStream.Position = 0;
		    Person person = (Person) xmlSerializer.Deserialize(memStream);
            Console.WriteLine(person);

			Console.WriteLine();
		}
	}
}
