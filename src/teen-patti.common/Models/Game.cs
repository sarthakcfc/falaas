using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teen_patti.common
{
    public class Game
    {
        private ICollection<GameState> _states;
        public Game()
        {
            _states = new List<GameState>();
        }
        public void Run()
        {

            //Create initial State
            Builder builder = new Builder();
            var gameState = builder
                .InitDeck(Card.NewTeenPattiDeck)
                .InitPlayers(Player.InitPlayers)
                .Build();

            Console.WriteLine(gameState.ToString());
            for (int i = 0; i < 6; i++)
            {
                var move = MoveFactory.CreateMove(gameState);
                gameState = move.Execute();
                Console.WriteLine(gameState.ToString());
            }

            //Gameplay
            bool isPlay = true;
            while(isPlay)
            {
                Console.WriteLine($"Player {gameState.CurrentPlayer.Ordinal} Turn");
                Console.WriteLine("S: See Cards, E: Exit Game");
                var input = Console.ReadLine();

                if (input.Trim().Equals("E"))
                {
                    isPlay = false;
                    break;
                }

                gameState = MoveFactory.CreateMove(gameState, input).Execute();
                Console.WriteLine(gameState.ToString());
            }

            
        }
    }
}
