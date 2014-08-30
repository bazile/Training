namespace BelhardTraining.LessonIO
{
	public static class NumericExtensions
	{
		/// <summary>
		/// Склонение численного существительного
		/// </summary>
		/// <param name="num"></param>
		/// <param name="one">Единственное число</param>
		/// <param name="little"></param>
		/// <param name="many">Множественное число</param>
		/// <returns></returns>
		public static string Pretty(this long num, string one, string little, string many)
		{
			if (num % 100 > 10 && num % 100 < 15)
			{
				return many;
			}
			if (num % 10 == 1)
			{
				return one;
			}
			if (num % 10 > 1 && num % 10 < 5)
			{
				return little;
			}
			return many;
		}

        public static string PrettyBytes(this long num)
        {
            return num.Pretty("байт", "байта", "байтов");
        }
	}
}
