﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS501_Project1
{
    class HumanPlayer : Player
    {
        public override void Deal(PlayingCard card)
        {
            card.FaceUp = true;
        }
    }
}
