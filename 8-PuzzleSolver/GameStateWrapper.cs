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

        public GameStateWrapper(GameState<T> gameState, double distanceFromStart, double finaldistance)
       => (GameState, DistanceFromStart, FinalDistance) = (gameState, distanceFromStart, finaldistance);
        public GameStateWrapper(GameState<T> gameState, GameStateWrapper<T> founderGameState, double distanceFromStart, double finaldistance)
        => (GameState, FounderGameState, DistanceFromStart, FinalDistance) = (gameState, founderGameState, distanceFromStart, finaldistance);
    }
}
