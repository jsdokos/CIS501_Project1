using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class HumanPlayer : Player
    {
        //sizeof hand is (53/#players + 2)

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
