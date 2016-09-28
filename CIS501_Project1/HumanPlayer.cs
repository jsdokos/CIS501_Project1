using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class HumanPlayer : Player
    {

        public HumanPlayer(int numPlayers, string name) : base(numPlayers, name)
        {
            isHuman = true;
        }
        public override void Deal(PlayingCard card)
        {
            card.FaceUp = true;
            topIndex++;
            Hand[topIndex] = card;
        }
    }
}
