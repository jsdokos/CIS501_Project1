using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    abstract class Player
    {
        public PlayingCard[] Hand;
        public int topIndex;
        public string Name; //TODO ??
        public CardDeck Deck;
        public static PlayingCard[] temp;
        public bool isHuman;

        public int NumCardsInHand
        {
            get
            {
                int count = 0;
                foreach (PlayingCard card in Hand)
                {
                    if (card != null)
                    {
                        count++;
                    }
                }
                return count;

            }
        }

        public Player(int numPlayers, string name)
        {
            Hand = new PlayingCard[53 / numPlayers + 2];
            Name = name;
            Deck = new CardDeck();
        }

        //Using example code from http://rosettacode.org/wiki/Knuth_shuffle
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < topIndex; i++)
            {
                int j = random.Next(i, topIndex);
                PlayingCard temp = Hand[i];
                Hand[i] = Hand[j];
                Hand[j] = temp;
            }
        }

        public void DiscardAllPairs()
        {
            temp = new PlayingCard[15];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = null;
            }

            for (int i = 0; i < Hand.Length; i++)
            {
                PlayingCard card = Hand[i];
                Hand[i] = null;

                if (card != null)
                {
                    if (temp[(int)card.Rank] == null)
                    {
                        temp[(int)card.Rank] = card;
                    }
                    else
                    {
                        temp[(int)card.Rank] = null;
                        card = null;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != null)
                {
                    Hand[count] = temp[i];
                    temp[i] = null;
                    count++;
                }
            }
            topIndex = count;//maybe?
        }

        public virtual void Deal(PlayingCard card)
        {         }

        public PlayingCard PickCardAt(int i)
        {
            PlayingCard temp = Hand[i];
            Hand[i] = Hand[topIndex];
            topIndex--;
            return temp;
        }

        public void AddCard(PlayingCard card)
        {
            //TODO find duplicates
            topIndex++;
            Hand[topIndex] = card;
            DiscardAllPairs();
        }

        public override string ToString() //TODO Wrong?
        {
            StringBuilder st = new StringBuilder();
            st.Append(this.Name + " : ");
            foreach (PlayingCard card in Hand)
            {
                if (card != null)
                {
                    st.Append(card.ToString() + " ");
                }
            }

            return st.ToString();
        }

        private void ReturnHandToDeck()
        {
            //TODO THIS
            foreach (PlayingCard card in Hand)
            {
                Deck.ReturnCard(card);
            }
        }
    }
}
