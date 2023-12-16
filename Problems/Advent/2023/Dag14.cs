using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag14 : Problem
{
    private const string testinput = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";
    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        var grid = new Grid<char>();
        foreach (var (line, y) in input.Split(Environment.NewLine).Reverse().Indexed())
        {
            foreach (var (c, x) in line.Indexed())
            {
                grid[x, y] = c;
            }
        }

        IList<long> loads = new List<long>();
        long target = 1000000000;
        while (true)
        {
            grid = Tilt(grid, GridDirection.North);
            grid = Tilt(grid, GridDirection.West);
            grid = Tilt(grid, GridDirection.South);
            grid = Tilt(grid, GridDirection.East);
            var load = Load(grid);
            Console.Write($"{load} ");
            loads.Add(load);
        }

        Result = Load(grid).ToString();

        Grid<char> Tilt(Grid<char> gridToTilt, GridDirection direction)
        {
            var newGrid = new Grid<char>();
            if (direction == GridDirection.North)
            {
                for (int x = 0; x <= gridToTilt.MaxX; x++)
                {
                    Queue<int> freeSpaces = new Queue<int>();
                    for (int y = gridToTilt.MaxY; y >= 0; y--)
                    {
                        var m = gridToTilt[x, y];
                        if (m == '#')
                        {
                            while (freeSpaces.TryDequeue(out var freeSpace))
                            {
                                newGrid[x, freeSpace] = '.';
                            }
                            newGrid[x, y] = '#';
                        }
                        else if (m == '.')
                        {
                            freeSpaces.Enqueue(y);
                        }
                        else if(freeSpaces.TryDequeue(out var freeSpace))
                        {
                            newGrid[x, freeSpace] = 'O';
                            freeSpaces.Enqueue(y);
                        }
                        else
                        {
                            newGrid[x, y] = 'O';
                        }
                    }

                    while (freeSpaces.TryDequeue(out var freeSpace))
                    {
                        newGrid[x, freeSpace] = '.';
                    }
                }
            }
            if (direction == GridDirection.South)
            {
                for (int x = 0; x <= gridToTilt.MaxX; x++)
                {
                    Queue<int> freeSpaces = new Queue<int>();
                    for (int y = 0; y <= gridToTilt.MaxY; y++)
                    {
                        var m = gridToTilt[x, y];
                        if (m == '#')
                        {
                            while (freeSpaces.TryDequeue(out var freeSpace))
                            {
                                newGrid[x, freeSpace] = '.';
                            }
                            newGrid[x, y] = '#';
                        }
                        else if (m == '.')
                        {
                            freeSpaces.Enqueue(y);
                        }
                        else if (freeSpaces.TryDequeue(out var freeSpace))
                        {
                            newGrid[x, freeSpace] = 'O';
                            freeSpaces.Enqueue(y);
                        }
                        else
                        {
                            newGrid[x, y] = 'O';
                        }
                    }

                    while (freeSpaces.TryDequeue(out var freeSpace))
                    {
                        newGrid[x, freeSpace] = '.';
                    }
                }
            }
            if (direction == GridDirection.West)
            {
                for (int y = 0; y <= gridToTilt.MaxY; y++)
                {
                    Queue<int> freeSpaces = new Queue<int>();
                    for (int x = 0; x <= gridToTilt.MaxX; x++)
                    {
                        var m = gridToTilt[x, y];
                        if (m == '#')
                        {
                            while (freeSpaces.TryDequeue(out var freeSpace))
                            {
                                newGrid[freeSpace, y] = '.';
                            }
                            newGrid[x, y] = '#';
                        }
                        else if (m == '.')
                        {
                            freeSpaces.Enqueue(x);
                        }
                        else if (freeSpaces.TryDequeue(out var freeSpace))
                        {
                            newGrid[freeSpace, y] = 'O';
                            freeSpaces.Enqueue(x);
                        }
                        else
                        {
                            newGrid[x, y] = 'O';
                        }
                    }

                    while (freeSpaces.TryDequeue(out var freeSpace))
                    {
                        newGrid[freeSpace, y] = '.';
                    }
                }
            }
            if (direction == GridDirection.East)
            {
                for (int y = 0; y <= gridToTilt.MaxY; y++)
                {
                    Queue<int> freeSpaces = new Queue<int>();
                    for (int x = gridToTilt.MaxX; x >= 0; x--)
                    {
                        var m = gridToTilt[x, y];
                        if (m == '#')
                        {
                            while (freeSpaces.TryDequeue(out var freeSpace))
                            {
                                newGrid[freeSpace, y] = '.';
                            }
                            newGrid[x, y] = '#';
                        }
                        else if (m == '.')
                        {
                            freeSpaces.Enqueue(x);
                        }
                        else if (freeSpaces.TryDequeue(out var freeSpace))
                        {
                            newGrid[freeSpace, y] = 'O';
                            freeSpaces.Enqueue(x);
                        }
                        else
                        {
                            newGrid[x, y] = 'O';
                        }
                    }

                    while (freeSpaces.TryDequeue(out var freeSpace))
                    {
                        newGrid[freeSpace, y] = '.';
                    }
                }
            }
            return newGrid;
        }

        long Load(Grid<char> gridToWeigh)
        {
            long res = 0;
            foreach (var member in grid.AllMembers())
            {
                if (member.value == 'O')
                {
                    res += member.y + 1;
                }
            }

            return res;
        }
    }

    public override int Nummer => 202314;
}