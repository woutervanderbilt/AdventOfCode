using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag06 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        int result = 0;
        foreach (var member in grid.AllGridMembers().Where(m => m.Value == '.').ToList())
        {
            var location = grid.AllGridMembers().Single(g => g.Value == '^');
            HashSet<(int, int, GridDirection direction)> path = [];
            var direction = GridDirection.North;

            grid[member.X, member.Y] = '#';
            while (location.Found)
            {
                if (!path.Add((location.Location.Item1, location.Location.Item2, direction)))
                {
                    result++;
                    break;
                }

                var next = grid.MoveInDirection(location.Location, direction);
                while (next.Found && next.Value == '#')
                {
                    direction = direction switch
                    {
                        GridDirection.East => GridDirection.South,
                        GridDirection.South => GridDirection.West,
                        GridDirection.West => GridDirection.North,
                        GridDirection.North => GridDirection.East,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    next = grid.MoveInDirection(location.Location, direction);
                }

                location = next;
            }

            grid[member.X, member.Y] = '.';
        }

        Result = result.ToString();
    }

    protected override string TestInput => @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

    override protected bool UseTestInput => false; 

    public override int Nummer => 202406;
}