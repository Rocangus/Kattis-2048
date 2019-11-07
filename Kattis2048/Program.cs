using System;

namespace Kattis2048
{
    class Program
    {
        static int rows, columns;
        static void Main(string[] args)
        {
            rows = columns = 4;
            var cellLines = new string[4];
            for (int i = 0; i < cellLines.Length; i++)
            {
                cellLines[i] = Console.ReadLine();
            }
            var moveDirection = int.Parse(Console.ReadLine());
            var cells = PopulateCellArrays(cellLines);
        }

        private static NumberCell[,] PopulateCellArrays(string[] cellLines)
        {
            var cells = new NumberCell[4, 4];
            for (int y = 0; y < rows; y++)
            {
                var values = cellLines[y].Split();
                for (int x = 0; x < columns; x++)
                {
                    cells[y, x] = new NumberCell(int.Parse(values[x]));
                }
            }
            return cells;
        }
    }
}
