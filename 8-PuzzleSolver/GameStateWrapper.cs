using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_PuzzleSolver
{
    public class GameStateWrapper<T>
    {
        public GameState<T> GameState;
        public GameStateWrapper<T>? FounderGameState;
        public double DistanceFromStart;
        public double FinalDistance;

        public GameStateWrapper(GameState<T> gameState, GameStateWrapper<T> founderGameState, double distanceFromStart, double finaldistance)
        {
            GameState = gameState;
            FounderGameState = founderGameState;
            DistanceFromStart = distanceFromStart;
            FinalDistance = finaldistance;
        }
    }
}
