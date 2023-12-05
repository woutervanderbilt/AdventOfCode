using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2022;

internal class Dag12 : Problem
{
    public override async Task ExecuteAsync()
    {
        var input = await GetInputAsync();
        var grid = new Grid<char>();

        (int, int) start = (0, 0);
        (int, int) target = (0, 0);

        int y = 0;
        foreach (var line in input.Split(Environment.NewLine))
        {
            int x = 0;
            foreach (var c in line)
            {
                grid[x, y] = c;
                if (c == 'S')
                {
                    start = (x, y);
                    grid[x, y] = 'a';
                }

                if (c == 'E')
                {
                    target = (x, y);
                    grid[x, y] = 'z';
                }
                x++;
            }

            y++;
        }

        grid.CanMove = (from, to) => to.Value - from.Value <= 1;

        var test = grid.ShortestPath(grid.AllMembers().Where(m => m.value == 'a').Select(m => (m.x, m.y)), new List<(int, int)> { target }, false);
        Console.WriteLine(new string(test.path.Select(s => s.Value).ToArray()));
        Result = test.cost.ToString();
    }

    public override int Nummer => 202212;
}