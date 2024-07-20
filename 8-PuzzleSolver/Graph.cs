using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _8_PuzzleSolver
{
    public class Graph<T>
    {
        public List<GameState<T>> GameStates { get; set; }
        public int GameStateCount => GameStates.Count;

        public Graph()
        {
            GameStates = new();
        }

        private bool VerifyPuzzle(int[,] current, int[,] goal)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (current[i, j] != goal[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool PuzzleDuplicateChecker(int[,] puzzle, HashSet<int[,]> visited)
        {
            for (int i = 0; i < visited.Count; i++)
            {
                if (VerifyPuzzle(puzzle, visited.ElementAt(i)))
                {
                    return true;
                }
            }
            return false;
        }


        public void AddGameState(GameState<T> GameState) 
        { 
            if (GameState != null && GameState.SuccessorCount <= 0 && !GameStates.Contains(GameState))
            {
                GameStates.Add(GameState);
            }
        }

        public bool AddSuccessor(GameState<T> start, GameState<T> end, double weight)
        {
            if (start != null && end != null && GameStates.Contains(start) && GameStates.Contains(end))
            {
                start.Successors.Add(new Successor<T>(start, end, weight));
                end.Successors.Add(new Successor<T>(end, start, weight));
                return true;
            }
            return false;
        }

        public GameState<T>? Search(List<T> possibleGameState)
        {
            for (int i = 0; i < GameStateCount; i++)
            {
                if (GameStates[i].PuzzlePieces.Equals(possibleGameState))
                {
                    return GameStates[i];
                }
            }
            return null;
        }

        //public GameStateWrapper<T> BFSSelector(List<GameStateWrapper<T>> frontier)
        //{
        //    GameStateWrapper<T> popped = frontier[0];
        //    frontier.RemoveAt(0);
        //    return popped;
        //}
        //public GameStateWrapper<T> DFSSelector(List<GameStateWrapper<T>> frontier)
        //{
        //    GameStateWrapper<T> dequeued = frontier[^1];
        //    frontier.RemoveAt(frontier.Count - 1);
        //    return dequeued;
        //}
        //public GameStateWrapper<T> DijkstraSelector(List<GameStateWrapper<T>> frontier)
        //{           
        //    GameStateWrapper<T>? optimalVertexWrapper = frontier[0];
        //    double minimumDistance = optimalVertexWrapper.DistanceFromStart;
        //    int optimalVertexWrapperIndex = 0;

        //    for (int i = 1; i < frontier.Count; i++)
        //    {
        //        if (minimumDistance > frontier[i].DistanceFromStart)
        //        {
        //            minimumDistance = frontier[i].DistanceFromStart;
        //            optimalVertexWrapper = frontier[i];
        //            optimalVertexWrapperIndex = i;
        //        }
        //    }

        //    frontier.RemoveAt(optimalVertexWrapperIndex);
        //    return optimalVertexWrapper;
        //}
        public GameStateWrapper<T> AStarSelector(List<GameStateWrapper<T>> frontier)
        {
            GameStateWrapper<T>? optimalVertexWrapper = frontier[0];
            double minimumDistance = optimalVertexWrapper.FinalDistance;
            int optimalVertexWrapperIndex = 0;

            for (int i = 1; i < frontier.Count; i++)
            {
                if (minimumDistance > frontier[i].FinalDistance)
                {
                    minimumDistance = frontier[i].FinalDistance;
                    optimalVertexWrapper = frontier[i];
                    optimalVertexWrapperIndex = i;
                }
            }

            frontier.RemoveAt(optimalVertexWrapperIndex);
            return optimalVertexWrapper;
        }
        public List<GameState<T>>? Solve(GameState<T> start)
        {
            GameState<T> end = GameStates[0];

            if (GameStates.Contains(start) && GameStates.Contains(end))
            {
                List<GameState<T>> result = new();
                List<GameStateWrapper<T>> frontier = new();
                HashSet<int[,]> visited = new();

                GameStateWrapper<T> current = new GameStateWrapper<T>(start, null, 0, Heuristics<T>.PiecesOutOfPlace(start));

                frontier.Add(current);

                visited.Add(start.PuzzlePieces);
                while (frontier.Count > 0)
                {
                    current = AStarSelector(frontier);
                    current.GameState.FindSuccessors();

                    foreach (var n in current.GameState.Successors)
                    {
                        if (!PuzzleDuplicateChecker(n.PotetionalGameState.PuzzlePieces, visited))
                        {
                            visited.Add(n.PotetionalGameState.PuzzlePieces);

                            double tentativeDistance = current.DistanceFromStart + n.Weight;
                            frontier.Add(new GameStateWrapper<T>(n.PotetionalGameState, current, tentativeDistance, Heuristics<T>.PiecesOutOfPlace(current.GameState)));
                        }

                        if (VerifyPuzzle(current.GameState.PuzzlePieces, end.PuzzlePieces))
                        {
                            GameStateWrapper<T> runner = current;
                            while (runner != null)
                            {
                                result.Add(runner.GameState);
                                runner = runner.FounderGameState;
                            }
                            result.Reverse();
                            return result;
                        }
                    }
                }
            }
            return null;
        }
    }
}
