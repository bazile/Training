using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo
{
    class Deck
    {
        public static PlayingCard[] Get36CardDeck()
        {
            PlayingCard[] cards = new PlayingCard[36];
            for (int i = 0, n = 0; i < 4; i++)
            {
                Suit suit = (Suit)i;
                for (int j = 0; j < 9; j++, n++)
                {
                    cards[n] = new PlayingCard(suit, (Rank)(6 + j));
                }
            }
            return cards;
        }
    }

    class PlayingCard
    {
        static string[] suitSymbols = { "\u2665", "\u2666", "\u2663", "\u2660" };

        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public PlayingCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return string.Format(
                "{0} of {1} {2}",
                Rank > Rank.D10 ? Rank.ToString() : ((int)Rank).ToString(),
                Suit,
                suitSymbols[(int)Suit]
            );
        }
    }

    enum Rank
    {
        D6=6, D7, D8, D9, D10,

        /// <summary>Валет</summary>
        Jack,

        /// <summary>Дама</summary>
        Queen,

        /// <summary>Король</summary>
        King,

        /// <summary>Туз</summary>
        Ace,
    }

    enum Suit
    {
        /// <summary>Червы</summary>
        Hearts,

        /// <summary>Бубны</summary>
        Diamonds,

        /// <summary>Трефы</summary>
        Clubs,

        /// <summary>Пики</summary>
        Spades
    }
}
