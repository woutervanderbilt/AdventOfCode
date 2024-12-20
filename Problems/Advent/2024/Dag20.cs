using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag20 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        var start = grid.AllGridMembers().Single(m => m.Value == 'S');
        var target = grid.AllGridMembers().Single(m => m.Value == 'E');
        grid.CanMove = (_, b) => b.Value != '#';
        var withoutCheats = grid.ShortestPath([start.Location], [target.Location], false);
        var distancesToStart = grid.Distances(start.Location);
        var distancesToEnd = grid.Distances(target.Location);
        int picoSecondsCutOff = UseTestInput ? 50 : 100;

        long CheatsWinningAtLeast(int picoseconds, int cheatLength)
        {
            Counter<long> saves = new Counter<long>();
            for (int dx = -cheatLength; dx <= cheatLength; dx++)
            {
                var maxDy = cheatLength - Math.Abs(dx);
                for (int dy = -maxDy; dy <= maxDy; dy++)
                {
                    foreach (var cheatStart in distancesToStart)
                    {
                        var cheatEnd = grid[cheatStart.Key.x + dx, cheatStart.Key.y + dy];
                        if (cheatEnd.Found && cheatEnd.Value != '#')
                        {
                            var totalCost = cheatStart.Value + distancesToEnd[cheatEnd.Location] + Math.Abs(dx) +
                                            Math.Abs(dy);
                            if (totalCost <= withoutCheats.cost - picoseconds)
                            {
                                saves[withoutCheats.cost - totalCost]++;
                            }
                        }
                    }
                }
            }

            return saves.Values.Sum();
        }

        Result = (CheatsWinningAtLeast(picoSecondsCutOff, 2), CheatsWinningAtLeast(picoSecondsCutOff, 20)).ToString();

    }
    protected override bool UseTestInput => false;

    protected override string TestInput => @"###############
#...#...#.....#
#.#.#.#.#.###.#
#S#...#.#.#...#
#######.#.#.###
#######.#.#...#
#######.#.###.#
###..E#...#...#
###.#######.###
#...###...#...#
#.#####.#.###.#
#.#...#.#.#...#
#.#.#.#.#.#.###
#...#...#...###
###############";
    public override int Nummer => 202420;
}