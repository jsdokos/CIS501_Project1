using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class PlayingCard
    {
        public enum CardSuit
        {
            Hearts=1,
            Diamonds,
            Clubs,
            Spades,
            Joker
        }

        private CardSuit Suit { get; }

        //0 Ace
        //1 2
        //2 3
        //3 4
        //4 5
        //5 6
        //6 7
        //7 8
        //8 9
        //9 10
        //10 Jack
        //11 Queen
        //12 King
        public int Rank { get { return Rank; } set { Rank = value; } }

        public bool FaceUp { get; set; }

        public PlayingCard(int rank, int suit)
        {
            Suit = (CardSuit) suit;
            if (rank >= 0 || rank <= 12)
            {
                Rank = rank;
            }
        }

        public override string ToString() //TODO FIX
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
