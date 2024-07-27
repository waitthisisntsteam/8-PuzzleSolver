using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _8_PuzzleSolver
{
    public class GameState<T>
    {
        public List<Successor<T>> Successors { get; set; }
        public int SuccessorCount => Successors.Count;
        public int[,] PuzzlePieces;

        public GameState(int[,] puzzlePieces)
        {
            PuzzlePieces = new int[puzzlePieces.GetLength(0), puzzlePieces.GetLength(1)];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { PuzzlePieces[i, j] = puzzlePieces[i, j]; }
            }
            Successors = new();
        }

        public List<Successor<T>>? FindSuccessors()
        {
            int[,] possiblePuzzle = PuzzlePieces;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (PuzzlePieces[i, j] == 0)
                    {
                        if (i > 0)
                        {
                            GameState<T> startingState = new GameState<T>(PuzzlePieces);
                            GameState<T> successor = startingState;

                            int swappablePiece = successor.PuzzlePieces[i - 1, j];
                            successor.PuzzlePieces[i, j] = swappablePiece;
                            successor.PuzzlePieces[i - 1, j] = 0;

                            Successors.Add(new Successor<T>(startingState, successor, 1));
                        }
                        if (i < 2)
                        {
                            GameState<T> startingState = new GameState<T>(PuzzlePieces);
                            GameState<T> successor = startingState;

                            int swappablePiece = successor.PuzzlePieces[i + 1, j];
                            successor.PuzzlePieces[i, j] = swappablePiece;
                            successor.PuzzlePieces[i + 1, j] = 0;

                            Successors.Add(new Successor<T>(startingState, successor, 1));
                        }
                        if (j > 0)
                        {
                            GameState<T> startingState = new GameState<T>(PuzzlePieces);
                            GameState<T> successor = startingState;

                            int swappablePiece = successor.PuzzlePieces[i, j - 1];
                            successor.PuzzlePieces[i, j] = swappablePiece;
                            successor.PuzzlePieces[i, j - 1] = 0;

                            Successors.Add(new Successor<T>(startingState, successor, 1));
                        }
                        if (j < 2)
                        {
                            GameState<T> startingState = new GameState<T>(PuzzlePieces);
                            GameState<T> successor = startingState;

                            int swappablePiece = successor.PuzzlePieces[i, j + 1];
                            successor.PuzzlePieces[i, j] = swappablePiece;
                            successor.PuzzlePieces[i, j + 1] = 0;

                            Successors.Add(new Successor<T>(startingState, successor, 1));
                        }
                        return Successors;
                    }
                }
            }

            return null;
        }
    }
}
