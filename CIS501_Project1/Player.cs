using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class Player
    {
        private PlayingCard[] Hand = new PlayingCard[53]; //TODO Change this

        private int topIndex;

        private string Name; //TODO ??

        private CardDeck Deck;

        public int NumCardsInHand
        {
            get { return Hand.Length;  }
        }


        private void Shuffle()
        {
            //TODO http://rosettacode.org/wiki/Knuth_shuffle
        }

        private void DiscardAllPairs()
        {
            
        }

        public virtual void Deal(PlayingCard card)
        {
            
        }

        private PlayingCard PickCardAt(int i)
        {
            
        }

        private void AddCard(PlayingCard card)
        {
            
        }

        public override string ToString()
        {
            
        }

        private void ReturnHandToDeck()
        {
            
        }
    }
}
