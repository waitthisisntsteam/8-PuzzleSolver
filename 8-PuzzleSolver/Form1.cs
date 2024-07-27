using System.Net.Http.Headers;

namespace _8_PuzzleSolver
{
    public partial class Form1 : Form
    {
        Point[] OrigianlPositions;
        private Button PreviouslyPressed;

        private Graph<int[,]> Puzzle;

        private int[,] CurrentPuzzle;
        private GameState<int[,]> CurrentGameState;

        private int[,] SolvedPuzzle;
        private GameState<int[,]> SolvedGameState;

        public Form1()
        {
            InitializeComponent();

            OrigianlPositions = [
                button1.Location, button2.Location, button3.Location, button4.Location, button5.Location, button6.Location, button7.Location, button8.Location, button9.Location
            ];
            PreviouslyPressed = button7;

            Puzzle = new();

            CurrentPuzzle = new[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 0 } };
            CurrentGameState = new GameState<int[,]>(CurrentPuzzle);

            SolvedPuzzle = new[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 0 } };
            SolvedGameState = new GameState<int[,]>(SolvedPuzzle);

            Puzzle.AddGameState(SolvedGameState);
            SolvedGameState.FindSuccessors();
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void Stall(int ticks)
        {
            for (int i = 0; i <= ticks; i++)
            { i++; }
        }

        private void scrambleClick(object sender, EventArgs e) //Scramble
        {
            int ticks = 0;
            Random rand = new();
            while (ticks <= 500)
            {
                int randInt = rand.Next(0, 9);

                if (randInt == 0)
                { puzzleClick(button7, e); }
                else if (randInt == 1)
                { PreviouslyPressed = button1; }
                else if (randInt == 2)
                { PreviouslyPressed = button2; }
                else if (randInt == 3)
                { PreviouslyPressed = button3; }
                else if (randInt == 4)
                { PreviouslyPressed = button6; }
                else if (randInt == 5)
                { PreviouslyPressed = button5; }
                else if (randInt == 6)
                { PreviouslyPressed = button4; }
                else if (randInt == 7)
                { PreviouslyPressed = button9; }
                else if (randInt == 8)
                { PreviouslyPressed = button8; }

                ticks++;
            }
        }
        private void solveClick(object sender, EventArgs e) //Solve
        {
            Puzzle.AddGameState(CurrentGameState);

            //disable clicking buttons

            var moves = Puzzle.Solve(CurrentGameState);

            if (moves == null)
            { return; }

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
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 2)
                            {
                                puzzleClick(button2, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 3)
                            {
                                puzzleClick(button3, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 4)
                            {
                                puzzleClick(button6, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 5)
                            {
                                puzzleClick(button5, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 6)
                            {
                                puzzleClick(button4, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 7)
                            {
                                puzzleClick(button9, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }
                            if (moves[i - 1].PuzzlePieces[j, k] == 8)
                            {
                                puzzleClick(button8, e);
                                puzzleClick(button7, e);
                                Stall(100000000);
                            }                                                  
                        }
                    }

                }
            }

            CurrentGameState = new GameState<int[,]>(CurrentPuzzle);
        }
        private void resetButton(object sender, EventArgs e)
        {
            button1.Location = OrigianlPositions[0];
            button2.Location = OrigianlPositions[1];
            button3.Location = OrigianlPositions[2];
            button4.Location = OrigianlPositions[3];
            button5.Location = OrigianlPositions[4];
            button6.Location = OrigianlPositions[5];
            button7.Location = OrigianlPositions[6];
            button8.Location = OrigianlPositions[7];
            button9.Location = OrigianlPositions[8];

            PreviouslyPressed = button7;
        }

        private void puzzleClick(object sender, EventArgs e) //Puzzle Piece
        {
            Button pressedButton = (Button)sender;

            if (pressedButton.Equals(button7))
            {
                double distance = Math.Abs(Math.Sqrt(Math.Pow((pressedButton.Location.X - PreviouslyPressed.Location.X), 2) + Math.Pow((pressedButton.Location.Y - PreviouslyPressed.Location.Y), 2)));
                if (distance < 280)
                {
                    Point emptyPosition = button7.Location;
                    button7.Location = PreviouslyPressed.Location;
                    PreviouslyPressed.Location = emptyPosition;

                    CurrentPuzzle[((button1.Location.X) / 200), ((button1.Location.Y) / 200)] = int.Parse(button1.Text);
                    CurrentPuzzle[((button2.Location.X) / 200), ((button2.Location.Y) / 200)] = int.Parse(button2.Text);
                    CurrentPuzzle[((button3.Location.X) / 200), ((button3.Location.Y) / 200)] = int.Parse(button3.Text);
                    CurrentPuzzle[((button4.Location.X) / 200), ((button4.Location.Y) / 200)] = int.Parse(button4.Text);
                    CurrentPuzzle[((button5.Location.X) / 200), ((button5.Location.Y) / 200)] = int.Parse(button5.Text);
                    CurrentPuzzle[((button6.Location.X) / 200), ((button6.Location.Y) / 200)] = int.Parse(button6.Text);                  
                    CurrentPuzzle[((button8.Location.X) / 200), ((button8.Location.Y) / 200)] = int.Parse(button8.Text);
                    CurrentPuzzle[((button9.Location.X) / 200), ((button9.Location.Y) / 200)] = int.Parse(button9.Text);
                    CurrentPuzzle[((button7.Location.X) / 200), ((button7.Location.Y) / 200)] = 0;

                    CurrentGameState = new GameState<int[,]>(CurrentPuzzle);
                }
            }
            else
            { PreviouslyPressed = pressedButton; }
        }    
    }
}
