using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Models;

namespace Algorithms.Extensions
{
    public static class GridExtensions
    {
        public static void Print(this Grid<char> grid, bool switchXandY = false)
        {
            var minX = grid.MinX;
            var maxX = grid.MaxX;
            var minY = grid.MinY;
            var maxY = grid.MaxY;
            if (switchXandY)
            {

                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = maxY; y >= minY; y--)
                    {
                        Console.Write(grid[x, y]);
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                for (int y = maxY; y >= minY; y--)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        Console.Write(grid[x, y]);
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void Print(this Grid<bool> grid, bool switchXandY = false)
        {
            var minX = grid.MinX;
            var maxX = grid.MaxX;
            var minY = grid.MinY;
            var maxY = grid.MaxY;
            if (switchXandY)
            {

                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = maxY; y >= minY; y--)
                    {
                        var value = grid[x, y];
                        Console.Write(value.Found && value.Value ? "#" : ".");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                for (int y = maxY; y >= minY; y--)
                {
                    for (int x = minX; x <= maxX; x++)
                    {
                        var value = grid[x, y];
                        Console.Write(value.Found && value.Value ? "#" : ".");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
