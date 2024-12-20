﻿using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag21 : Problem
{
    private const string input = @"../.. => .##/..#/##.
#./.. => ##./#../#..
##/.. => ###/#.#/..#
.#/#. => .../#../##.
##/#. => ###/#../###
##/## => .##/.##/#.#
.../.../... => #.##/#.##/###./..##
#../.../... => ##.#/..##/#.#./##.#
.#./.../... => ###./.#.#/.#../.###
##./.../... => ##.#/###./..../##..
#.#/.../... => ##.#/.###/.##./#.#.
###/.../... => #..#/.##./#.../.#.#
.#./#../... => .##./####/#..#/###.
##./#../... => ##../..#./#.##/..##
..#/#../... => #.##/.#.#/##../..##
#.#/#../... => #.../##../..#./.##.
.##/#../... => #.#./.#.#/#.##/#..#
###/#../... => .#../.#../...#/##..
.../.#./... => ..#./..#./##../.#.#
#../.#./... => ##../####/##../.###
.#./.#./... => ..../#..#/#.#./....
##./.#./... => ..##/####/..../##..
#.#/.#./... => #.##/##../#.../..#.
###/.#./... => ..../..../####/#..#
.#./##./... => ..../####/##.#/....
##./##./... => ####/#.../.###/#.##
..#/##./... => .#.#/.#../###./.#..
#.#/##./... => .#.#/###./..../..##
.##/##./... => #.../.#.#/.#.#/...#
###/##./... => #.##/.#../.#../#...
.../#.#/... => ###./..#./.#../..##
#../#.#/... => #..#/#.##/.#../...#
.#./#.#/... => ####/..#./..../..#.
##./#.#/... => #.#./..../.###/..#.
#.#/#.#/... => #..#/.#../#.#./.###
###/#.#/... => .##./#..#/.#.#/..#.
.../###/... => .#../#..#/...#/.##.
#../###/... => .##./##../###./##.#
.#./###/... => ...#/..##/###./...#
##./###/... => .#.#/##.#/.###/.#..
#.#/###/... => #.#./##../#.#./..#.
###/###/... => .#.#/####/###./####
..#/.../#.. => .#../#.##/..../..#.
#.#/.../#.. => ..../.#.#/##../#..#
.##/.../#.. => #.##/.#.#/#..#/.#.#
###/.../#.. => #..#/.#.#/#.#./##.#
.##/#../#.. => ##../##.#/##.#/#..#
###/#../#.. => ..../#..#/###./#.##
..#/.#./#.. => ..../.#../..../.##.
#.#/.#./#.. => #..#/#.##/.###/....
.##/.#./#.. => ###./..../##.#/#.#.
###/.#./#.. => #.../###./.#.#/..#.
.##/##./#.. => ..../.#../..#./#.#.
###/##./#.. => ...#/.###/###./####
#../..#/#.. => ..../.##./..##/..##
.#./..#/#.. => .#.#/#.../#..#/###.
##./..#/#.. => #.#./.##./.##./....
#.#/..#/#.. => #..#/..##/##.#/##..
.##/..#/#.. => ..#./#.../.##./##.#
###/..#/#.. => ##../.##./####/.##.
#../#.#/#.. => ###./#.#./###./.#.#
.#./#.#/#.. => .##./#.#./#..#/..#.
##./#.#/#.. => .#.#/#.#./#.../##.#
..#/#.#/#.. => .##./##.#/.#.#/.#.#
#.#/#.#/#.. => .#../.##./###./#...
.##/#.#/#.. => ####/##../.##./##.#
###/#.#/#.. => ###./.##./##.#/#...
#../.##/#.. => ...#/#.#./..##/####
.#./.##/#.. => #.../##.#/.##./###.
##./.##/#.. => ##.#/.#.#/..../#.#.
#.#/.##/#.. => ..../#.../.#.#/..#.
.##/.##/#.. => ##../..../..#./#.##
###/.##/#.. => ..#./...#/#..#/...#
#../###/#.. => ..../.#../#.../###.
.#./###/#.. => ..../#.#./.#.#/...#
##./###/#.. => ###./###./..#./.###
..#/###/#.. => #.##/..#./..##/#...
#.#/###/#.. => ##.#/.#.#/##../#..#
.##/###/#.. => ###./..##/#.../....
###/###/#.. => .###/###./#.../..#.
.#./#.#/.#. => ..##/##.#/.##./####
##./#.#/.#. => ..../.#.#/#.../###.
#.#/#.#/.#. => ##.#/###./..#./.#..
###/#.#/.#. => .###/##../.###/....
.#./###/.#. => ####/.###/.###/....
##./###/.#. => #.#./#..#/#..#/###.
#.#/###/.#. => #.#./.#.#/#.##/####
###/###/.#. => #.#./.###/..#./#.#.
#.#/..#/##. => ###./.#.#/##../##..
###/..#/##. => #.../.###/#.../..#.
.##/#.#/##. => #..#/.#.#/...#/.#..
###/#.#/##. => ...#/###./..##/.#.#
#.#/.##/##. => ###./...#/..../#...
###/.##/##. => ...#/#.../#.##/##..
.##/###/##. => .###/.###/..#./#...
###/###/##. => #.../##../##.#/.###
#.#/.../#.# => ##../#.##/..#./.###
###/.../#.# => #.#./.##./.##./#..#
###/#../#.# => #.../##../####/..##
#.#/.#./#.# => #.../.#../#.../..##
###/.#./#.# => #..#/###./####/#...
###/##./#.# => ##../..##/#.#./##..
#.#/#.#/#.# => .#../.#.#/#.#./.#.#
###/#.#/#.# => ..##/####/####/.###
#.#/###/#.# => .###/##../#..#/..#.
###/###/#.# => ##../#.../##.#/##..
###/#.#/### => ###./...#/####/..#.
###/###/### => .##./##../..../..#.";

    private const string testinput = @"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";
    public override Task ExecuteAsync()
    {
        IDictionary<string, string> mapping = new Dictionary<string, string>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split(' ');
            var fromGrid = StringToGrid(words[0]);
            for (int r = 0; r < 4; r++)
            {
                var rotatedFrom = fromGrid.Rotate(r);
                var rotatedFromString = GridToString(rotatedFrom);
                if (!mapping.ContainsKey(rotatedFromString))
                {
                    mapping[rotatedFromString] = words[2];
                    var flippedFromString = GridToString(rotatedFrom.FlipX());
                    if (!mapping.ContainsKey(flippedFromString))
                    {
                        mapping[flippedFromString] = words[2];
                    }
                }
            }
        }

        var grid = new Grid<char>();
        grid[0, 0] = '.';
        grid[0, 1] = '#';
        grid[0, 2] = '.';
        grid[1, 0] = '.';
        grid[1, 1] = '.';
        grid[1, 2] = '#';
        grid[2, 0] = '#';
        grid[2, 1] = '#';
        grid[2, 2] = '#';

        for (int i = 0; i < 18; i++)
        {
            //grid.Print(true);
            Console.WriteLine(i);
            grid = Step();
        }

        Result = grid.AllMembers().Count(t => t.value == '#').ToString();


        Grid<char> Step()
        {
            var newGrid = new Grid<char>();
            var gridSize = (int)Math.Sqrt(grid.Size);
            var minX = grid.MinX;
            var minY = grid.MinY;
            int size = gridSize % 2 == 0 ? 2 : 3;

            for (int x = 0; x < gridSize; x += size)
            {
                for (int y = 0; y < gridSize; y += size)
                {
                    var subgrid = new Grid<char>();
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            subgrid[i, j] = grid[minX + x + i, minY + y + j];
                        }
                    }

                    var mappedSubGrid = StringToGrid(mapping[GridToString(subgrid)]);
                    var msMinX = mappedSubGrid.MinX;
                    var msMinY = mappedSubGrid.MinY;
                    for (int i = 0; i < size + 1; i++)
                    {
                        for (int j = 0; j < size + 1; j++)
                        {
                            newGrid[x / size * (size + 1) + i, y / size * (size + 1) + j] = mappedSubGrid[msMinX + i, msMinY + j];
                        }
                    }
                }
            }

            return newGrid;
        }

        return Task.CompletedTask;

        Grid<char> StringToGrid(string gridString)
        {
            var grid = new Grid<char>();
            int x = 0, y = 0;
            foreach (var c in gridString)
            {
                if (c == '/')
                {
                    x = 0;
                    y++;
                }
                else
                {
                    grid[x, y] = c;
                    x++;
                }
            }

            return grid;
        }

        string GridToString(Grid<char> grid)
        {
            var sb = new StringBuilder();
            bool first = true;
            for (int y = grid.MinY; y <= grid.MaxY; y++)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append("/");
                }
                for (int x = grid.MinX; x <= grid.MaxX; x++)
                {
                    sb.Append(grid[x, y]);
                }
            }

            return sb.ToString();
        }
    }

    public override int Nummer => 201721;
}