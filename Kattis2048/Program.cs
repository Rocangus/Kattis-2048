using System;

namespace Kattis2048
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellLines = new string[4];
            for (int i = 0; i < cellLines.Length; i++)
            {
                cellLines[i] = Console.ReadLine();
            }
            var moveDirection = int.Parse(Console.ReadLine());
        }
    }
}
