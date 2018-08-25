using System;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
    /// <summary>
    /// Информация о пассажире Титаника
    /// </summary>
	public class TitanicPassenger : IEquatable<TitanicPassenger>
	{
        /// <summary>
        /// Класс (первый, второй, третий) или специализация для членов команды
        /// </summary>
		public Class Class { get; set; }

        /// <summary>
        /// Обращение в начале имени (Mr, Mrs, Miss, Sr и т.д.)
        /// </summary>
        public string HonorificPrefix { get; set; }

        /// <summary>
        /// Обращение в конце имени (Jr)
        /// </summary>
        public string HonorificSuffix { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
		public string FamilyName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Выжил при крушении корабля?
        /// </summary>
        public bool HasSurvived { get; set; }

        /// <summary>
        /// Член гарантийной группы верфи Harland and Wolff?
        /// </summary>
        public bool IsGuaranteeGroupMember { get; set; }

        /// <summary>
        /// Слуга?
        /// </summary>
        public bool IsServant { get; set; }

        /// <summary>
        /// Возраст в месяцах (значение может отсутствовать)
        /// </summary>
		public int? AgeMonths { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Дата смерти
        /// </summary>
        public DateTime? DeathDate { get; set; }

        /// <summary>
        /// Адрес места рождения
        /// </summary>
		public Address BirthAddress { get; set; }

        /// <summary>
        /// Номер билета
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// Номер каюты
        /// </summary>
        public string CabinNo { get; set; }

        /// <summary>
        /// Цена билета (в старых фунтах)
        /// </summary>
        public Price TicketPrice { get; set; }

        /// <summary>
        /// В каком городе сел на корабль
        /// </summary>
		public City Boarded { get; set; } // Переименовать в Embarked?

        /// <summary>
        /// Профессия
        /// </summary>
		public string JobTitle { get; set; }

        /// <summary>
        /// Номер спасательной шлюпки
        /// </summary>
        public string Lifeboat { get; set; }

		public string Url { get; set; }

		[System.Xml.Serialization.XmlAttribute("id")]
		public string Id { get; set; }

        /// <summary>
        /// Полное имя пассажира
        /// </summary>
		public string FullName
		{
			get { return HonorificPrefix + " " + FamilyName + ", " + GivenName + (string.IsNullOrEmpty(HonorificSuffix) ? "" : " " + HonorificSuffix); }
		}

        /// <summary>
        /// Номер палубы
        /// </summary>
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

        /// <summary>
        /// Возрастная группа
        /// </summary>
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

	public static class Titanic
	{
		public static readonly Price Price = new Price("£1500000");
		public static DateTime SunkDate = new DateTime(1912, 4, 15, 2, 20, 0);
	}
}
