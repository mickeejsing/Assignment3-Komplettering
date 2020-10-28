using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        private List<Card> m_hand = new List<Card>();
        private List<IDealCardsObserver> m_subscribers;

        public Player()
        {
            m_subscribers = new List<IDealCardsObserver>();
        }

        public virtual void AddSubscriber(IDealCardsObserver sub)
        {
            m_subscribers.Add(sub);
        }

        public virtual void NotifySubscribers(/*object playerType*/)
        {
            /*
            foreach (var obs in m_subscribers)
            {
                if(playerType == Player) {
                    obs.DealCardsToPlayer(GetHand(), 1);
                }

                if(playerType == Dealer) {
                    obs.DealCardsToDealer(GetHand(), 1);
                }
            }
            */

            foreach (var obs in m_subscribers)
            {
                obs.DynamicDisplayPlayerHand(GetHand(), CalcScore(), "Player");
            }
        }

        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
            NotifySubscribers();
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }

        // Added class.
        public bool IsSoftSeventeen() {
            foreach (Card c in GetHand())
            {
                if(c.GetValue() == Card.Value.Ace) {
                    return true;
                }
            }

            return false;
        }
    }
}
