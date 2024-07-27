using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_PuzzleSolver
{
    public class Heuristics<T>
    {
        public static double PiecesOutOfPlace(GameState<T> puzzle)
        {
            double piecesOutOfPlace = 0;
            int[,] solvedPuzzle = new[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 0 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzle.PuzzlePieces[i, j] != solvedPuzzle[i, j])
                    { piecesOutOfPlace++; }
                }
            }

            return piecesOutOfPlace;
        }
    }
}
