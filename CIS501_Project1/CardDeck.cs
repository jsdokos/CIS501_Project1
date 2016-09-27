using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class CardDeck
    {
        private PlayingCard[] Deck = new PlayingCard[53];

        private int topIndex;

        public CardDeck() //finish making old maid
        {
            int count = 0;
            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Deck[count] = new PlayingCard(i, j, false);
                    count++;
                }
            }
            //Deck[52] = new PlayingCard(5, );
        }

        public CardDeck(int suit, int rank)
        {
            
        }

        public PlayingCard Draw()
        {
            PlayingCard temp = Deck[topIndex];
            Deck[topIndex] = null;
            topIndex--; // ???
            return temp;
        }

        //Using example code from http://rosettacode.org/wiki/Knuth_shuffle
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Deck.Length; i++)
            {
                int j = random.Next(i, Deck.Length);
                PlayingCard temp = Deck[i];
                Deck[i] = Deck[j];
                Deck[j] = temp;
            }
        }

        private void ReturnCard(PlayingCard card)
        {
            topIndex++;
            Deck[topIndex] = card;
        }
    }
}
