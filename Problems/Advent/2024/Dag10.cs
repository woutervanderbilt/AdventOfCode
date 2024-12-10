using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag10 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<int>.FromInput(Input, c => int.Parse(new string(new[] { c })));
        grid.CanMove = (f, t) => t == f + 1;
        var trailHeads = grid.AllGridMembers().Where(m => m.Value == 0).ToList();
        long result1 = 0, result2 = 0;
        foreach (var trailHead in trailHeads)
        {
            CounterLong<(int, int)> visited = new CounterLong<(int, int)>();
            visited[trailHead.Location] = 1;
            for (int i = 1; i <= 9; i++)
            {
                var newCounter = new CounterLong<(int, int)>();
                foreach (var location in visited.Keys)
                {
                    var v = visited[location];
                    foreach (var neighbour in grid.Neighbours(location, false))
                    {
                        newCounter[neighbour.Location] += v;
                    }
                }

                visited = newCounter;
            }

            result1 += grid.AllGridMembers().Count(m => m.Value == 9 && visited[m.Location] > 0);
            result2 += grid.AllGridMembers().Where(m => m.Value == 9).Sum(m => visited[m.Location]); ;
        }

        Result = (result1, result2).ToString();
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732";

    public override int Nummer => 202410;
}