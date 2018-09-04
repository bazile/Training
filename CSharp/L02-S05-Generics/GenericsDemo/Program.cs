using System;
using System.Linq;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Обычный вариант

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ArrayHelper.Shuffle(numbers);
            Console.WriteLine(string.Join("; ", numbers));

            string[] letters = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й" };
            ArrayHelper.Shuffle(letters);
            Console.WriteLine(string.Join("; ", letters));

            //PlayingCard[] deck = Deck.Get36CardDeck();
            //ArrayHelper.Shuffle(deck);

            #endregion

            #region Вариант с обобщенной реализацией

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //ArrayHelper.Shuffle<int>(numbers);
            //Console.WriteLine(string.Join("; ", numbers));

            //string[] letters = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й" };
            //ArrayHelper.Shuffle<string>(letters);
            //Console.WriteLine(string.Join("; ", letters));

            //PlayingCard[] deck = Deck.Get36CardDeck();
            //ArrayHelper.Shuffle<PlayingCard>(deck);

            #endregion
        }
    }
}
