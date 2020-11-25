using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            DealCard(a_deck, a_player, true);
            DealCard(a_deck, a_dealer, true);
            DealCard(a_deck, a_player, true);

            return true;
        }

        public void DealCard(Deck deck, Player player, bool show) {
            
            Card c;

            c = deck.GetCard();
            c.Show(show);
            player.DealCard(c);
        }
    }
}
