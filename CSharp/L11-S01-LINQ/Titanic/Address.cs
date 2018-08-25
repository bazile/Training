using System;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
    public class Address : IEquatable<Address>
	{
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }

		public Address()
		{
			Country = "";
			State = "";
			City = "";
		}

		public bool Equals(Address other)
		{
			return string.Equals(Country, other.Country)
				&& string.Equals(State, other.State)
				&& string.Equals(City, other.City);
		}

		public override string ToString()
		{
			string s = Country;
			if (State.Length > 0)
			{
				if (s.Length > 0) s += ", ";
				s += State;
			}
			if (City.Length > 0)
			{
				if (s.Length > 0) s += ", ";
				s += City;
			}
			return s;
		}
	}
}
