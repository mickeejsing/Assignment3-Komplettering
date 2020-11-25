using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame: IDealCardsObserver
    {   
        private model.Game a_game;
        private view.IView a_view;

        public PlayGame(model.Game a_game, view.IView a_view) {
            this.a_game = a_game;
            this.a_view = a_view;
            a_game.AddSubscriber(this);

        }

        public bool Play()
        {   
            bool keepPlaying = true;
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }


            Enum input = a_view.GetInput();

            if(input != null) {

                switch (input)
                {
                    case ViewEnums.Play: a_game.NewGame(); break;
                    case ViewEnums.Hit: a_game.Hit(); break;
                    case ViewEnums.Stand: a_game.Stand(); break;
                    case ViewEnums.Quit: keepPlaying = false; break;
                    default: break;
                }
            }

            return keepPlaying;
        }

        public void DynamicDisplayHand(dynamic a_hand, int a_score, string name) {
            a_view.DynamicDisplayCards(name, a_hand, a_score);
            Thread.Sleep(3000);
        }
    }
}
