using System;

namespace Kattis2048
{
    public enum Direction { left, up, right, down}
    public class Program
    {
        static int rows, columns, actions;
        static NumberCell[,] cells;
        static void Main(string[] args)
        {
            rows = columns = 4;
            var cellLines = new string[4];
            for (int i = 0; i < cellLines.Length; i++)
            {
                cellLines[i] = Console.ReadLine();
            }
            var moveDirection = int.Parse(Console.ReadLine());
            cells = PopulateCellArrays(cellLines);
            do
            {
                actions = 0;
                cells = ProcessMove(cells, moveDirection);
            } while (actions > 0);
            PrintResults();
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
                } 
            }
            return cells;
        }

        private static NumberCell[,] ProcessMove(NumberCell[,] cells, int moveDirection)
        {
            MoveCells((Direction)moveDirection);
            
            return cells;
        }

        private static void MoveCells(Direction moveDirection)
        {
            Tuple<int, int> moveFactor;
            switch (moveDirection)
            {
                case Direction.left:
                    moveFactor = Tuple.Create(0, -1);
                    break;
                case Direction.up:
                    moveFactor = Tuple.Create(-1, 0);
                    break;
                case Direction.right:
                    moveFactor = Tuple.Create(0, 1);
                    break;
                case Direction.down:
                    moveFactor = Tuple.Create(1, 0);
                    break;
                default:
                    moveFactor = Tuple.Create(0, 0);
                    break;
            }
            MergeOrMove(moveFactor);
        }

        private static void MergeOrMove(Tuple<int, int> moveFactor)
        {
            int changeY, changeX;
            changeY = changeX = 1;
            if (moveFactor.Item1 < 0)
            {
                changeY = -1;
            }
            if (moveFactor.Item2 < 0)
            {
                changeX = -1;
            }
            
            // Process actions "bottom up" to produce expected merge behavior, see Sample 5
            for (int y = changeY == 1? 3 : 0; InRange(y); y -= changeY)
            {
                for (int x = changeX == 1 ? 3 : 0; InRange(x); x -= changeX)
                {
                    var cell = cells[y, x];
                    var pos = cell.Position;
                    pos = AddPositions(pos, moveFactor);
                    var newY = pos.Item1;
                    var newX = pos.Item2;
                    if (InRange(newY)&&InRange(newX))
                    {
                        var nextCell = cells[newY, newX];
                        if (cells[newY, newX].Value == 0)
                        {
                            cells[newY, newX] = cell;
                            cell.SetPosition(pos);
                            cells[y, x] = NumberCell.EmptyCell;
                            actions++;
                        }
                        else if (!(cell.Merged || nextCell.Merged) && cell.Value == nextCell.Value)
                        {
                            cell = NumberCell.Merge(cell, nextCell);
                            cells[newY, newX] = cell;
                            cell.SetPosition(pos);
                            cells[y, x] = NumberCell.EmptyCell;
                            actions++;
                        } 
                    }
                }
            }
        }

        private static bool InRange(int i)
        {
            return i < 4 && 0 <= i;
        }

        private static Tuple<int, int> AddPositions(Tuple<int, int> tuple1, Tuple<int, int> tuple2)
        {
            return Tuple.Create(tuple1.Item1 + tuple2.Item1, tuple1.Item2 + tuple2.Item2);
        }

        private static void PrintResults()
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (x < columns - 1) Console.Write(cells[y,x].Value + " ");
                    else Console.Write(cells[y, x].Value + "\n");
                }
            }
        }
    }
}
