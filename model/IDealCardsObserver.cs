using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IDealCardsObserver
{
    void DynamicDisplayPlayerHand(dynamic a_hand, int a_score, string name);
}