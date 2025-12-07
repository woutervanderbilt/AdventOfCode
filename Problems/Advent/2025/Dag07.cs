using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2025;
internal class Dag07 : Problem
{
    public override Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        int width = grid.MaxX;
        long[] beams = new long[width + 1];
        beams[grid.AllMembers().Single(m => m.value == 'S').x] = 1;
        long result = 0;
        long result2 = 1;
        for (int y = grid.MaxY; y >= 0; y--)
        {
            long[] newBeams = new long[width + 1];
            for (int x = 0; x <= width; x++)
            {
                var b = beams[x];
                if (b == 0)
                {
                    continue;
                }

                if (grid[x, y] == '^')
                {
                    newBeams[x-1] += b;
                    newBeams[x+1] += b;
                    result++;
                    result2 += b;
                }
                else
                {
                    newBeams[x] += b;
                }
            }

            beams = newBeams;
        }


        Result = (result, result2).ToString();
        return Task.CompletedTask;
    }
    protected override string TestInput => @".......S.......
...............
.......^.......
...............
......^.^......
...............
.....^.^.^.....
...............
....^.^...^....
...............
...^.^...^.^...
...............
..^...^.....^..
...............
.^.^.^.^.^...^.
...............";

    protected override bool UseTestInput => false;
    public override int Nummer => 202507;
}