using System;
using System.Collections.Generic;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
    public static class TitanicPassengerComparer
    {
        private static Lazy<TitanicPassengerPriceComparer> _priceComparer;

        static TitanicPassengerComparer()
        {
            _priceComparer = new Lazy<TitanicPassengerPriceComparer>(() => new TitanicPassengerPriceComparer());
        }

        public static IComparer<TitanicPassenger> PriceComparer
        {
            get { return _priceComparer.Value; }
        }

		class TitanicPassengerPriceComparer : IComparer<TitanicPassenger>
		{
			public int Compare(TitanicPassenger x, TitanicPassenger y)
			{
				return x.TicketPrice.CompareTo(y.TicketPrice);
			}
		}

	}
}
