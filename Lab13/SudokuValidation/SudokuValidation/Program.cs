using System;
using System.Collections.Generic;

namespace SudokuValidation
{
    class Program
    {
        public static bool IsValidSudoku(char[][] board)
        {
            var length = board.Length;

            var columns = new HashSet<(int, char)>();
            var rows = new HashSet<(int, char)>();
            var squares = new HashSet<(int, int, char)>();

            for (var row = 0; row < length; row++)
            {
                for (var column = 0; column < length; column++)
                {
                    var value = board[row][column];

                    if (value == '.')
                    {
                        continue;
                    }

                    if (rows.Add((row, value)) &&
                        columns.Add((column, value)) &&
                        squares.Add((row / 3, column / 3, value)))
                    {
                        continue;
                    }

                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var board = new[]
            {
                new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Console.WriteLine(IsValidSudoku(board));

            board = new[]
            {
                new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Console.WriteLine(IsValidSudoku(board));
        }
    }
}
