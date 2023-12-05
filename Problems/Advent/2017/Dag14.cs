using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2017;

internal class Dag14 : Problem
{
    private const string input = "uugsqrei";
    public override Task ExecuteAsync()
    {
        long total = 0;
        var grid = new Grid<bool>();
        for (int i = 0; i < 128; i++)
        {
            var hash = new KnotHash($"{input}-{i}").GetHash();
            int j = 0;
            foreach (var d in hash)
            {
                int h = Convert.ToInt32(d.ToString(), 16);
                int p = 8;
                for (int k = 0; k < 4; k++)
                {
                    if ((h & p) != 0)
                    {
                        total++;
                        grid[i, j] = true;
                    }
                    j++;
                    p /= 2;
                }
            }
        }

        int groupCount = grid.GroupCount(false);
        Result = $"{total} {groupCount}";
        return Task.CompletedTask;
    }

    public override int Nummer => 201714;
}