using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IResultStrategy m_ResultRule;
        private List<IDealCardsObserver> m_subscribers;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_ResultRule = a_rulesFactory.GetResultRule();
            m_subscribers = new List<IDealCardsObserver>();
        }

        public override void NotifySubscribers(/*object playerType*/)
        {
            foreach (var obs in m_subscribers)
            {
                obs.DynamicDisplayHand(GetHand(), CalcScore(), "Dealer");
            }
        }

        public override void AddSubscriber(IDealCardsObserver sub)
        {
            m_subscribers.Add(sub);
        }

        public void Stand()
        {
            if(m_deck != null) {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {   
                    GetShowDealCard(this, true);
                }
            }
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {   

                GetShowDealCard(a_player, true);

                return true;
            }
            return false;
        }
        
        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            } 
            
            // Added code.
            else if (CalcScore() > a_player.CalcScore()) {
                return true;
            }

            else if (CalcScore() < a_player.CalcScore()) {
                return false;
            }

            return m_ResultRule.IsDealerWinnerEqualScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
        
        private void GetShowDealCard(Player player, bool show) {
            NotifySubscribers();
            Card c = m_deck.GetCard();
            c.Show(show);
            player.DealCard(c);
        }
    }
}
