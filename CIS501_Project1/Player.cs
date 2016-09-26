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

        //Using example code from http://rosettacode.org/wiki/Knuth_shuffle
        private void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Hand.Length; i++)
            {
                int j = random.Next(i, Hand.Length);
                PlayingCard temp = Hand[i];
                Hand[i] = Hand[j];
                Hand[j] = temp;
            }
        }

        private void DiscardAllPairs()
        {
            
        }

        public virtual void Deal(PlayingCard card)
        {
        
        }

        private PlayingCard PickCardAt(int i)
        {
            PlayingCard temp = Hand[i];
            Hand[i] = Hand[topIndex];
            topIndex--;
            return temp;
        }

        private void AddCard(PlayingCard card)
        {
            //TODO find duplicates
            topIndex++;
            Hand[topIndex] = card;
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            foreach (PlayingCard card in Hand)
            {
                st.Append(card.ToString() + " ");
            }

            return st.ToString();
        }

        private void ReturnHandToDeck()
        {
            
        }
    }
}
