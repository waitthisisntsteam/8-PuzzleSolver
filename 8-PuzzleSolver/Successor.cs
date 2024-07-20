using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_PuzzleSolver
{
    public class Successor <T>
    {
        public GameState<T> GameState;
        public GameState<T> PotetionalGameState;
        public double Weight;

        public Successor(GameState<T> startingPoint, GameState<T> endingPoint, double weight)
        => (GameState, PotetionalGameState, Weight) = (startingPoint, endingPoint, weight);
    }
}
