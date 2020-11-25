using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
            //return new SoftSeventeenHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            //return new AmericanNewGameStrategy();
            return new InternationalNewGameStrategy();
        }

        // Added code.
        public IResultStrategy GetResultRule()
        {
            // return new DealerWinsResultStrategy();
            return new DealerLosesResultStrategy();
        }
    }
}
