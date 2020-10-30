using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            // Added code.
            if(a_dealer.CalcScore() == g_hitLimit && a_dealer.IsSoftSeventeen()) {
                return true;
            } else if(a_dealer.CalcScore() < g_hitLimit) {
                return true;
            } else {
                return false;
            }
        }
    }
}
