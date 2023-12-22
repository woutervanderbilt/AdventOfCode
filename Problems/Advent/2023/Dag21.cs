using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag21 : Problem
{
    const string testinput = @"...........
.....###.#.
.###.##..#.
..#.#...#..
....#.#....
.##..S####.
.##..#...#.
.......##..
.##.#.####.
.##..##.##.
...........";

    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        var grid = Grid<char>.FromInput(input, c => c);
        var s = grid.AllMembers().Single(m => m.value == 'S');
        grid.CanMove = (_, m) => m.Value != '#'; 
        var reachable = ReachableLocations((s.x, s.y), 64, grid);
        

        Console.WriteLine();


        // oneven grids: 7697
        // even grids: 7730
        // magic numbers ftw
        int target = 26501365;
        int stepsToEdge = 26501235;
        long maxFullGrid = 202299;
        long odds = maxFullGrid % 2 == 0 ? (maxFullGrid + 1) * (maxFullGrid + 1) : maxFullGrid * maxFullGrid;
        long evens = maxFullGrid % 2 == 1 ? (maxFullGrid + 1) * (maxFullGrid + 1) : maxFullGrid * maxFullGrid;

        long result2 = odds * 7697 + evens * 7730;

        var remaining = 130;
        var gridTimes4 = new Grid<char>();
        for (int y = 0; y < 262; y++)
        {
            for (int x = 0; x < 262; x++)
            {
                gridTimes4[x, y] = grid[x % 131, y % 131];
            }
        }
        gridTimes4.CanMove = (_, m) => m.Value != '#';

        var r = ReachableLocations((130, 65), remaining, grid);
        var l = ReachableLocations((0, 65), remaining, grid);
        var d = ReachableLocations((65, 0), remaining, grid);
        var u = ReachableLocations((65, 130), remaining, grid);

        var r1 = ReachableLocations((261, 65), remaining, gridTimes4);
        var l1 = ReachableLocations((0, 65), remaining, gridTimes4);
        var d1 = ReachableLocations((65, 0), remaining, gridTimes4);
        var u1 = ReachableLocations((65, 261), remaining, gridTimes4);
        var r2 = ReachableLocations((261, 196), remaining, gridTimes4);
        var l2 = ReachableLocations((0, 196), remaining, gridTimes4);
        var d2 = ReachableLocations((196, 0), remaining, gridTimes4);
        var u2 = ReachableLocations((196, 261), remaining, gridTimes4);



        result2 += r.Count + l.Count + d.Count + u.Count +
                   maxFullGrid * (new HashSet<(int, int)>(r.Concat(d)).Count +
                                  new HashSet<(int, int)>(r.Concat(u)).Count +
                                  new HashSet<(int, int)>(l.Concat(d)).Count +
                                  new HashSet<(int, int)>(l.Concat(u)).Count);
        result2 += (maxFullGrid + 1) *
                   (new HashSet<(int,int)>(d2.Where(m => m is { Item1: < 131, Item2: < 131 })
                       .Concat(r1.Where(m => m is { Item1: > 130, Item2: > 130 })
                           .Select(m => (m.Item1 - 131, m.Item2 - 131)))).Count +

                    new HashSet<(int, int)>(d1.Where(m => m is { Item1: > 130, Item2: < 131 })
                        .Select(m => (m.Item1 - 131, m.Item2))
                        .Concat(l1.Where(m => m is { Item1: < 131, Item2: > 130 })
                            .Select(m => (m.Item1, m.Item2 - 131)))).Count +

                    new HashSet<(int, int)>(l2.Where(m => m is { Item1: < 131, Item2: < 131 })
                        .Concat(u1.Where(m => m is { Item1: > 130, Item2: > 130 })
                            .Select(m => (m.Item1 - 131, m.Item2 - 131)))).Count +

                    new HashSet<(int, int)>(r2.Where(m => m is { Item1: > 130, Item2: < 131 })
                        .Select(m => (m.Item1 - 131, m.Item2))
                        .Concat(u2.Where(m => m is { Item1: < 131, Item2: > 130 })
                            .Select(m => (m.Item1, m.Item2 - 131)))).Count);



        Result = (reachable.Count, result2).ToString();

        HashSet<(int, int)> ReachableLocations((int x, int y) l, int steps, Grid<char> gridToUse)
        {
            HashSet<(int, int)> reachable = new HashSet<(int, int)> { l };
            for (int i = 1; i <= steps; i++)
            {
                var newReachable = new HashSet<(int, int)>();
                foreach (var location in reachable)
                {
                    foreach (var neighbour in gridToUse.Neighbours(location, false))
                    {
                        newReachable.Add(neighbour.Location);
                    }
                }

                reachable = newReachable;
            }

            return reachable;
        }
    }

    public override int Nummer => 202321;
}