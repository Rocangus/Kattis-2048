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
            cells = processMove(cells, moveDirection);
        }

        private static NumberCell[,] PopulateCellArrays(string[] cellLines)
        {
            var cells = new NumberCell[4, 4];
            for (int y = 0; y < rows; y++)
            {
                var values = cellLines[y].Split();
                for (int x = 0; x < columns; x++)
                {
                    var position = Tuple.Create(y, x);
                    cells[y, x] = new NumberCell(int.Parse(values[x]), position);
                } //TODO: Make move methods that make use of y and x and backtrack until the bounds of the multidimensional NumberCell array to move cells after any merging.
            }
            return cells;
        }

        private static NumberCell[,] processMove(NumberCell[,] cells, int moveDirection)
        {
            return cells;
        }
    }
}
