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
            OldMaid
        }

        private CardSuit Suit { get; }
        static readonly string[] arraySuits = { "C", "H", "D", "S", "O" };
        static readonly string[] arrayRanks = { "M", "A", "2", "3", "4", "5", "6", "7", "8", "9", "0", "J", "Q", "K" };

        public int Rank { get; set; }

        public bool FaceUp { get; set; }

        public PlayingCard(int rank, int suit, bool face)
        {
            this.Rank = rank;
            Suit = (CardSuit) suit;
            FaceUp = face;
        }

        public override string ToString() 
        {
            if (this.FaceUp)
            {
                return arraySuits[(int) Suit - 1] + arrayRanks[Rank];
            }
            else
            {
                return "XX";
            }
        }
    }
}
