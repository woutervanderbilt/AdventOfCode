using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Models;

namespace Algorithms.Extensions;

public static class GridExtensions
{
    public static void Print(this Grid<char> grid, bool switchXandY = false, bool reverseY = false)
    {
        var minX = grid.MinX;
        var maxX = grid.MaxX;
        var minY = reverseY ? grid.MaxY : grid.MinY;
        var maxY = reverseY ? grid.MinY : grid.MaxY;
        var dy = reverseY ? -1 : 1;
        if (switchXandY)
        {

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = maxY; reverseY ? y <= minY : y >= minY; y+= dy)
                {
                    Console.Write(grid[x, y]);
                }

                Console.WriteLine();
            }
        }
        else
        {
            for (int y = maxY; reverseY ? y <= minY : y >= minY; y -= dy)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Console.Write(grid[x, y]);
                }

                Console.WriteLine();
            }
        }
    }

    public static void Print(this Grid<bool> grid, bool switchXandY = false, char t = '#', char f = '.')
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
                    Console.Write(value.Found && value.Value ? t : f);
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
                    Console.Write(value.Found && value.Value ? t : f);
                }

                Console.WriteLine();
            }
        }
    }

    public static void Print<T>(this Grid<T> grid, Func<T, char> map, bool switchXandY = false)
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
                    Console.Write(map(grid[x, y]));
                }

                Console.WriteLine();
            }
        }
        else
        {
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    Console.Write(map(grid[x, y]));
                }

                Console.WriteLine();
            }
        }
    }
}