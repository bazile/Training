using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
	class Program
	{
		static void Main(string[] args)
		{
			TitanicPassenger[] passengers = LoadPassengers();

			// Факты:
			//   Музыканты: номер билета 250654
			//   Впередсмотрящие (Lookout) в ночь катастрофы: Frederick Fleet и LEE, Reginald Robinson

			// В фильме Титаник главные герои жили в каютах B-52, B-54, and B-56, G-60

			var temp = passengers.Where(pax => pax.JobTitle.Is("Lookout"));

			Console.WriteLine(passengers.Length);
			Console.WriteLine(passengers.Max(p => p.TicketPrice));
			Console.WriteLine(passengers.Where(p => p.TicketPrice.TotalPence > 0).Min(p => p.TicketPrice));
			//Console.WriteLine(passengers.Sum(p => p.TicketPrice));
			return;


			IEnumerable<TitanicPassenger> r1 = from pax in passengers
                     orderby pax.TicketPrice
                     select pax;
            IEnumerable<IGrouping<Class, TitanicPassenger>> r2 = from pax in passengers
                     group pax by pax.Class into paxGroup
                     select paxGroup;

            // Aggregate
            Price totalPrice = passengers.Aggregate(
                new Price(),
                (curPrice, pax) => curPrice += pax.TicketPrice
            );
            Console.WriteLine(passengers.Max(p => p.TicketPrice));
            Console.WriteLine("{0:N}", passengers.Max(p => p.TicketPrice).ModernEquivalent);
            Console.WriteLine();
            Console.WriteLine(totalPrice);
            Console.WriteLine(Titanic.Price);
            Console.WriteLine();
            Console.WriteLine("{0:N}", totalPrice.ModernEquivalent);
            Console.WriteLine("{0:N}", Titanic.Price.ModernEquivalent);
            Console.WriteLine();

            // Min, Max
            Console.WriteLine(passengers.Select(p => p.AgeMonths).Min());
            Console.WriteLine(passengers.Select(p => p.AgeMonths).Max()/12.0);
			Console.WriteLine(passengers.Max(p => p.AgeMonths) / 12.0);

			//Console.WriteLine(passengers.Where(p => p.Sex == Sex.Unknown).Count());

			// Sum
			//passengers.Sum(pax => pax.Price)

			//passengers.OrderBy()

			////double totalPrice = passengers
			////	.Where(pax => pax.Class == Class.First)
			////	.Select(pax => pax.Price.ModernEquivalent)
			////	.Sum();
			////Price totalPrice2 = (Price)passengers
			////	.Where(pax => pax.Class == Class.First)
			////	.Sum(pax => pax.Price);
			////Console.WriteLine(totalPrice.ToString("C", CultureInfo.GetCultureInfo("en-GB")));
			////Console.WriteLine(totalPrice2.ToString());
			////Console.WriteLine(totalPrice2.ModernEquivalent.ToString("C", CultureInfo.GetCultureInfo("en-GB")));

			//Console.WriteLine(passengers.Count);
			//Console.WriteLine(passengers.Count());

			//var r1 = from pax in passengers where pax.Class == Class.First select pax;
			////var r2 = passengers.Where(pax => pax.Class == Class.First).Select(pax => pax);
			//var r3 = passengers.Where(pax => pax.Class == Class.First);

			//Console.WriteLine(passengers.All(pax => pax.HasSurvived));
			//Console.WriteLine(passengers.Any(pax => pax.HasSurvived));


			////var firstClassPassengers = new List<TitanicPassenger>();
			////foreach (TitanicPassenger pax in passengers)
			////{
			////	if (pax.Class == Class.First)
			////	{
			////		firstClassPassengers.Add(pax);
			////	}
			////}
			////firstClassPassengers.Sort((pax1,pax2) => -pax1.Price.CompareTo(pax2.Price));
			////List<TitanicPassenger> firstClassPassengers = (
			////		from pax in passengers
			////		where pax.Class == Class.First
			////		orderby pax.Price descending, pax.FullName
			////		select pax
			////	).ToList();
			////IList<TitanicPassenger> firstClassPassengers2 =
			////	passengers
			////	.Where(pax => pax.Class == Class.First)
			////	.OrderByDescending(pax => pax.Price)
			////		.ThenBy(pax => pax.FullName)
			////	.ToList()
			////	.Shuffle();
			////Console.WriteLine(firstClassPassengers.SequenceEqual(firstClassPassengers2));
			////var passengersByClass = 
			////	from pax in passengers
			////	group pax by pax.Class into classGroup
			////	select new { Class = classGroup.Key, Count = classGroup.Count() } into cac
			////	orderby cac.Count
			////	select cac
			////;
			////foreach (var cac in passengersByClass)
			////{
			////	Console.WriteLine($"{cac.Class} {cac.Count}");
			////}
			////foreach (IGrouping<Class,TitanicPassenger> classGroup in passengersByClass)
			////{
			////	Console.WriteLine(classGroup.Key);
			////	foreach (TitanicPassenger pax in classGroup)
			////	{
			////		Console.Write(".");
			////	}
			////	Console.WriteLine();
			////}
			//Console.WriteLine();
			////Console.WriteLine(firstClassPassengers.Count);

			////passengers.OrderBy(p => p.FamilyName).Dump();
			////passengers.Where(p => p.FamilyName == "FLEET").Dump();
			////passengers.Where(p => p.Job == "Lookout").Dump();
			//// SMITH, Edward John -> Captain
			//// MURDOCH, William McMaster -> 1st officer
			//// FLEET, Frederick -> Lookout (one who spotted the iceberg)
			//// LEE, Reginald Robinson -> Lookout

			////passengers.Select(p => p.Job).Distinct().OrderBy(j => j).Dump();
			////passengers.Where(p => p.Job == "Musician").Dump();
			////passengers.Where(p=> p.IsServant).Dump();
			////passengers.Where(p => p.IsGuaranteeGroupMember).OrderBy(p => p.FamilyName).Dump();
			////passengers.Where(p => p.Price > 0).OrderBy(p => p.Price).Take(10).Dump();
			////passengers.Where(p => p.Price == 0).Dump();
			////((Price)passengers.Sum(p => p.Price)).Dump();
			////	passengers.Where(p => p.Price > 0).GroupBy(p => p.Class).Select(g => new {
			////		Class = g.Key,
			////		Min = g.Min(p => p.Price),
			////		Max = g.Max(p => p.Price),
			////		Avg = (Price)(int)g.Average(p => p.Price)
			////	}).Dump();
			////passengers.GroupBy(p => p.Class).Select(pg => new { pg.Key, x = pg.Count() }).Dump();
			////passengers.GroupBy(p => p.TicketNo).Select(pg => new { pg.Key, Cnt = pg.Count() }).Where(x => x.Cnt > 1).OrderByDescending(x => x.Cnt).Dump();
			////passengers.Where(p => p.TicketNo == "2343").Dump();
			////passengers.Select(p => p.Lifeboat).Distinct().OrderBy(lb => lb).Dump();
		}

		static TitanicPassenger[] LoadPassengers()
		{
			Type t = typeof(Program);
			string resourceName = t.Namespace + ".titanic.xml.zip";
			using (var fstream = t.Assembly.GetManifestResourceStream(resourceName))
			using (var zip = new ZipArchive(fstream, ZipArchiveMode.Read))
			{
				using (var entryStream = zip.GetEntry("titanic.xml").Open())
				{
					XmlSerializer s = new XmlSerializer(typeof(TitanicPassenger[]));
					return (TitanicPassenger[])s.Deserialize(entryStream);
				}
			}
		}
	}
}
