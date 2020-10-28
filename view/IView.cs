using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    interface IView
    {
        void DisplayWelcomeMessage();
        int GetInput();
        void DisplayCard(model.Card a_card);
        void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayGameOver(bool a_dealerIsWinner);

        // Added methods.
        bool IsPlay(int input);
        bool IsHit(int input);
        bool IsStand(int input);
        bool IsQuit(int input);

        //Test
        void DynamicDisplayCardsForPlayer(string name, dynamic a_hand, int a_score);
    }
}
