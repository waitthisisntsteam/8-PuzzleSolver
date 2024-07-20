using System.Net.Http.Headers;

namespace _8_PuzzleSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point[]? origianlPositions;
        private Button? previouslyPressed;

        private Graph<int[,]>? puzzle;

        private int[,]? currentPuzzle;
        private GameState<int[,]>? currentGameState;

        private int[,]? solvedPuzzle;
        private GameState<int[,]>? solvedGameState;

        bool solving;

        private void Form1_Load(object sender, EventArgs e)
        {
            origianlPositions = [ button1.Location, button2.Location, button3.Location, button4.Location, button5.Location, button6.Location, button7.Location, button8.Location, button9.Location ];
            previouslyPressed = button7;

            puzzle = new();

            currentPuzzle = new[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 0 } };
            currentGameState = new GameState<int[,]>(currentPuzzle);

            solvedPuzzle = new[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 0 } };
            solvedGameState = new GameState<int[,]>(solvedPuzzle);

            puzzle.AddGameState(solvedGameState);
            solvedGameState.FindSuccessors();

            solving = false;
        }

        private void Stall(int ticks)
        {
            for (int i = 0; i <= ticks; i++)
            {
                i++;
            }
        }

        private void scrambleClick(object sender, EventArgs e) //Scramble
        {
            int ticks = 0;
            Random rand = new();
            while (ticks <= 500)
            {
                int randInt = rand.Next(0, 9);

                if (randInt == 0)
                {
                    puzzleClick(button7, e);
                }
                else if (randInt == 1)
                {
                    previouslyPressed = button1;
                }
                else if (randInt == 2)
                {
                    previouslyPressed = button2;
                }
                else if (randInt == 3)
                {
                    previouslyPressed = button3;
                }
                else if (randInt == 4)
                {
                    previouslyPressed = button6;
                }
                else if (randInt == 5)
                {
                    previouslyPressed = button5;
                }
                else if (randInt == 6)
                {
                    previouslyPressed = button4;
                }
                else if (randInt == 7)
                {
                    previouslyPressed = button9;
                }
                else if (randInt == 8)
                {
                    previouslyPressed = button8;
                }

                ticks++;
            }
        }
        private void solveClick(object sender, EventArgs e) //Solve
        {
            puzzle.AddGameState(currentGameState);

            //disable clicking buttons

            var moves = puzzle.Solve(currentGameState);
            solving = moves != null;

            //visualize path

            for (int i = 1; i < moves.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (moves[i].PuzzlePieces[j, k] != moves[i - 1].PuzzlePieces[j, k])
                        {
                            if (moves[i - 1].PuzzlePieces[j, k] == 1)
                            {                              
                                puzzleClick(button1, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 2)
                            {
                                puzzleClick(button2, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 3)
                            {
                                puzzleClick(button3, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 4)
                            {
                                puzzleClick(button6, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 5)
                            {
                                puzzleClick(button5, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 6)
                            {
                                puzzleClick(button4, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 7)
                            {
                                puzzleClick(button9, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 8)
                            {
                                puzzleClick(button8, e);
                                Stall(100000000);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }                                                  
                        }
                    }

                }
            }

            currentGameState = new GameState<int[,]>(currentPuzzle);
            solving = false;
        }
        private void resetButton(object sender, EventArgs e)
        {
            button1.Location = origianlPositions[0];
            button2.Location = origianlPositions[1];
            button3.Location = origianlPositions[2];
            button4.Location = origianlPositions[3];
            button5.Location = origianlPositions[4];
            button6.Location = origianlPositions[5];
            button7.Location = origianlPositions[6];
            button8.Location = origianlPositions[7];
            button9.Location = origianlPositions[8];

            previouslyPressed = button7;
        }

        private void puzzleClick(object sender, EventArgs e) //Puzzle Piece
        {
            Button pressedButton = (Button)sender;

            if (pressedButton.Equals(button7))
            {
                double distance = Math.Abs(Math.Sqrt(Math.Pow((pressedButton.Location.X - previouslyPressed.Location.X), 2) + Math.Pow((pressedButton.Location.Y - previouslyPressed.Location.Y), 2)));
                if (distance < 280)
                {
                    Point emptyPosition = button7.Location;
                    button7.Location = previouslyPressed.Location;
                    previouslyPressed.Location = emptyPosition;

                    currentPuzzle[((button1.Location.X) / 200), ((button1.Location.Y) / 200)] = int.Parse(button1.Text);
                    currentPuzzle[((button2.Location.X) / 200), ((button2.Location.Y) / 200)] = int.Parse(button2.Text);
                    currentPuzzle[((button3.Location.X) / 200), ((button3.Location.Y) / 200)] = int.Parse(button3.Text);
                    currentPuzzle[((button4.Location.X) / 200), ((button4.Location.Y) / 200)] = int.Parse(button4.Text);
                    currentPuzzle[((button5.Location.X) / 200), ((button5.Location.Y) / 200)] = int.Parse(button5.Text);
                    currentPuzzle[((button6.Location.X) / 200), ((button6.Location.Y) / 200)] = int.Parse(button6.Text);                  
                    currentPuzzle[((button8.Location.X) / 200), ((button8.Location.Y) / 200)] = int.Parse(button8.Text);
                    currentPuzzle[((button9.Location.X) / 200), ((button9.Location.Y) / 200)] = int.Parse(button9.Text);
                    currentPuzzle[((button7.Location.X) / 200), ((button7.Location.Y) / 200)] = 0;

                    if (!solving)
                    {
                        currentGameState = new GameState<int[,]>(currentPuzzle);
                    }
                }
            }
            else
            {
                previouslyPressed = pressedButton;
            }
        }    
    }
}
