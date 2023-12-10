using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static bool player1Turn = true;

        static void Main(string[] args)
        {
            InitializeBoard();

            bool gameEnded = false;
            int moves = 0;

            while (gameEnded == false)
            {
                DrawBoard();

                int row, col;

                do
                {
                    Console.WriteLine($"Player {(player1Turn ? 'X' : 'O')}, enter row (0-2) and column (0-2), separated by space:");
                    string[] input = Console.ReadLine().Split(' ');
                    row = int.Parse(input[0]);
                    col = int.Parse(input[1]);
                } while (!IsValidMove(row, col));

                board[row, col] = player1Turn ? 'X' : 'O';
                moves++;

                gameEnded = CheckForWin() || moves == 9;
                player1Turn = !player1Turn;
            }

            DrawBoard();
            if (CheckForWin())
            {
                Console.WriteLine($"Player {(player1Turn ? 'O' : 'X')} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                return false;
            }

            return board[row, col] == ' ';
        }

        static bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }

            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }
    }
}
