using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag18 : Problem
{
    public override async Task ExecuteAsync()
    {
        int size = UseTestInput ? 6 : 70;
        int take = UseTestInput ? 12 : 1024;
        var grid = new Grid<int>();
        var split = Input.Split(Environment.NewLine);
        for (int x = 0; x <= size; x++)
        {
            for (int y = 0; y <= size; y++)
            {
                grid[x, y] = 0;
            }
        }
        foreach (var (line, index) in split.Indexed().Take(take))
        {
            var coordinates = line.FindAllNumbersAsInt().ToList();
            grid[coordinates[0], coordinates[1]] = index + 1;
        }

        grid.CanMove = (_, b) => b.Value == 0;
        var shortestPath = grid.ShortestPath([(0, 0)], [(size, size)], false);
        var path = new HashSet<(int, int)>(shortestPath.path.Select(m => (m.X, m.Y)));
        var result1 = shortestPath.cost;
        for (int t = take + 1; t <= size * size; t++)
        {
            var coordinates = split[t].FindAllNumbersAsInt().ToList();
            grid[coordinates[0], coordinates[1]] = t;

            if (path.Contains((coordinates[0], coordinates[1])))
            {
                shortestPath = grid.ShortestPath([(0, 0)], [(size, size)], false);
                if (!shortestPath.found)
                {
                    Result = (result1, string.Join(',', coordinates)).ToString();
                    break;
                }
                path = [..shortestPath.path.Select(m => (m.X, m.Y))];
            }
        }
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"5,4
4,2
4,5
3,0
2,1
6,3
2,4
1,5
0,6
3,3
2,6
5,1
1,2
5,5
2,5
6,5
1,4
0,4
6,4
1,1
6,1
1,0
0,5
1,6
2,0";

    public override int Nummer => 202418;
}