using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class PlayingCard
    {
        enum CardSuit
        {
            Joker,
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        private CardSuit Suit { get; }

        private int Rank { get; }

        private bool FaceUp { get; }

        public PlayingCard(int Suit, int Rank)
        {
            this.Suit = (CardSuit) Suit;
            this.Rank = Rank;
        }

        public override string ToString()
        {
            if (FaceUp)
            {
                return Suit.ToString() + Rank;
            }
            else
            {
                return "XX";
            }
        }
    }
}
