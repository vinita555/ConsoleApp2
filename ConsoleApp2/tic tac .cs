using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    internal class TicTacToe
    { 
        class Program
        {
            static void Main(string[] args)
            {
                char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
                char currentPlayer = 'X';
                bool gameEnded = false;

                while (!gameEnded)
                {
                    Console.Clear();
                    DrawBoard(board);

                    int move = GetPlayerMove(board);
                    board[move] = currentPlayer;

                    if (CheckWin(board, currentPlayer))
                    {
                        Console.Clear();
                        DrawBoard(board);
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameEnded = true;
                    }
                    else if (IsBoardFull(board))
                    {
                        Console.Clear();
                        DrawBoard(board);
                        Console.WriteLine("It's a tie!");
                        gameEnded = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            static void DrawBoard(char[] board)
            {
                Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            }

            static int GetPlayerMove(char[] board)
            {
                int move = -1;
                bool validMove = false;

                while (!validMove)
                {
                    Console.Write("Enter your move (0-8): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out move) && move >= 0 && move < 9 && board[move] == ' ')
                    {
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }

                return move;
            }

            static bool CheckWin(char[] board, char player)
            {
                // Check rows
                for (int i = 0; i < 9; i += 3)
                {
                    if (board[i] == player && board[i + 1] == player && board[i + 2] == player)
                    {
                        return true;
                    }
                }

                // Check columns
                for (int i = 0; i < 3; i++)
                {
                    if (board[i] == player && board[i + 3] == player && board[i + 6] == player)
                    {
                        return true;
                    }
                }

                // Check diagonals
                if ((board[0] == player && board[4] == player && board[8] == player) ||
                    (board[2] == player && board[4] == player && board[6] == player))
                {
                    return true;
                }

                return false;
            }

            static bool IsBoardFull(char[] board)
            {
                foreach (char cell in board)
                {
                    if (cell == ' ')
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
