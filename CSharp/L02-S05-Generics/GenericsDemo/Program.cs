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

            PlayingCard[] deck = (
                from CardSuit suit in Enum.GetValues(typeof(CardSuit))
                from CardValue value in Enum.GetValues(typeof(CardValue))
                select new PlayingCard { Suit = suit, Value = value }
            ).ToArray();
            ArrayHelper.Shuffle<PlayingCard>(deck);
        }
    }

    class PlayingCard
    {
        public CardSuit Suit;
        public CardValue Value;

        public override string ToString()
        {
            string[] suitSymbols = { "\u2660", "\u2665", "\u2666", "\u2663" };
            return string.Format("{0} of {1}",
                Value > CardValue.Card10 ? Value.ToString() : ((int)Value).ToString(),
                suitSymbols[(int)Suit]
            );
        }
    }

    /// <summary>
    /// Масти карт
    /// </summary>
    enum CardSuit
    {
        /// <summary>Пики</summary>
        Spades,
        /// <summary>Червы</summary>
        Hearts,
        /// <summary>Бубны</summary>
        Diamonds,
        /// <summary>Трефы</summary>
        Clubs
    }

    enum CardValue
    {
        Card6 = 6, Card7 = 7, Card8 = 8, Card9 = 9, Card10 = 10,
        Jack, Queen, King
    }
}
