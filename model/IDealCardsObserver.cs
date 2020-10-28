using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IDealCardsObserver
{
    //void DealCardsToPlayer(/*IEnumerable<Card> Player, */int score);
    //void DealCardsToDealer(/*IEnumerable<Card> Player, */int score);
    void DynamicDisplayPlayerHand(dynamic a_hand, int a_score);
    void DynamicDisplayDealerHand(dynamic a_hand, int a_score);
}