// ADDED CLASS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicResultStrategy : IResultStrategy
    {
        private const Boolean isDealerWinnerEqual = true;

        public bool IsDealerWinnerEqualScore()
        {   
            return isDealerWinnerEqual;
        }
    }
}
