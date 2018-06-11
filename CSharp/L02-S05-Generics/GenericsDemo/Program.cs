using System;
using System.Linq;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ArrayHelper.Shuffle<int>(numbers);

            string[] letters = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й" };
            ArrayHelper.Shuffle<string>(letters);

            PlayingCard[] deck = Deck.Get36CardDeck();
            ArrayHelper.Shuffle<PlayingCard>(deck);
        }
    }
}
