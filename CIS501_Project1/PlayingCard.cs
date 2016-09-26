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
            Joker=1,
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        private CardSuit Suit { get; }

        //0 2
        //1 3
        //2 4
        //3 5
        //4 6
        //5 7
        //6 8
        //7 9
        //8 10
        //9 Jack
        //10 Queen
        //11 King
        //12 Ace
        private int Rank { get; }

        public bool FaceUp { get; set; }

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
