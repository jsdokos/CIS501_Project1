using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CIS501_Project1
{
    
    class ComputerPlayer : Player
    {
        public ComputerPlayer(int numPlayers, string name) : base(numPlayers, name)
        {
            isHuman = false;
        }
        public string MakeCardIndices()
        {
            StringBuilder st = new StringBuilder();
            st.Append("Index :  ");
            for (int i = 0; i < NumCardsInHand; i ++)
            {
                st.Append(i + "  "); //TODO adjust formatting
            }

            return st.ToString();
        }

        public override void Deal(PlayingCard card)
        {
#if DEBUG
            card.FaceUp = true;
#else
            card.FaceUp = false;
#endif
            topIndex++;
            Hand[topIndex] = card;
        }
    }
}
