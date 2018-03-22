using System;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
	public enum Class
	{
		Unknown,
		First, Second, Third,
		DeckCrew, EngineeringCrew, VictuallingCrew
	}

	public enum Sex { Unknown, Male, Female }
	public enum City { Belfast, Southampton, Cherbourg, Queenstown }
	public enum AgeGroup { Unknown, Infant, Child, Teenager, Adult, Senior }
	public enum Deck { Unknown, A, B, C, D, E, F, G }

	public class TitanicPassenger : IEquatable<TitanicPassenger>
	{
		public Class Class { get; set; }
		public string HonorificPrefix { get; set; }
		public string HonorificSuffix { get; set; }
		public string FamilyName { get; set; }
		public string GivenName { get; set; }
		public Sex Sex { get; set; }
		public bool HasSurvived { get; set; }
		public bool IsGuaranteeGroupMember { get; set; }
		public bool IsServant { get; set; }

		public int? AgeMonths { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? DeathDate { get; set; }

		public Address BirthAddress { get; set; }
		public string TicketNo { get; set; }
		public string CabinNo { get; set; }
		public Price TicketPrice { get; set; }
		public City Boarded { get; set; } // Переименовать в Embarked?
		public string JobTitle { get; set; }
		public string Lifeboat { get; set; }
		public string Url { get; set; }

		[System.Xml.Serialization.XmlAttribute("id")]
		public string Id { get; set; }

		public string FullName
		{
			get { return HonorificPrefix + " " + FamilyName + ", " + GivenName + (string.IsNullOrEmpty(HonorificSuffix) ? "" : " " + HonorificSuffix); }
		}

		public Deck Deck
		{
			get
			{
				Deck deck = default(Deck);
				if (CabinNo != null)
				{
					Enum.TryParse<Deck>(CabinNo.Substring(0, 1), out deck);
				}
				return deck;
			}
		}

		public AgeGroup AgeGroup
		{
			get
			{
				if (!AgeMonths.HasValue) return AgeGroup.Unknown;
				int years = AgeMonths.Value / 12;
				if (years < 2) return AgeGroup.Infant;
				if (years >= 2 && years < 13) return AgeGroup.Child;
				if (years >= 13 && years < 20) return AgeGroup.Teenager;
				if (years >= 20 && years < 60) return AgeGroup.Adult;
				return AgeGroup.Senior;
			}
		}

		public bool Equals(TitanicPassenger pax)
		{
			return (
				Class == pax.Class
				&& string.Equals(HonorificPrefix, pax.HonorificPrefix, StringComparison.OrdinalIgnoreCase)
				&& string.Equals(FamilyName, pax.FamilyName, StringComparison.OrdinalIgnoreCase)
				&& string.Equals(GivenName, pax.GivenName, StringComparison.OrdinalIgnoreCase)
				&& Sex == pax.Sex
				&& HasSurvived == pax.HasSurvived
				&& IsGuaranteeGroupMember == pax.IsGuaranteeGroupMember
				&& IsServant == pax.IsServant
				&& AgeMonths == pax.AgeMonths
				&& string.Equals(TicketNo, pax.TicketNo, StringComparison.OrdinalIgnoreCase)
				&& TicketPrice == pax.TicketPrice
				&& Boarded == pax.Boarded
				&& string.Equals(JobTitle, pax.JobTitle, StringComparison.OrdinalIgnoreCase)
				&& string.Equals(Lifeboat, pax.Lifeboat, StringComparison.OrdinalIgnoreCase)
			);
		}

		public override string ToString()
		{
			return FullName;
		}
	}

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

	public static class Titanic
	{
		public static readonly Price Price = new Price("£1500000");
		public static DateTime SunkDate = new DateTime(1912, 4, 15, 2, 20, 0);
	}
}
