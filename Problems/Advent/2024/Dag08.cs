using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag08 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        HashSet<(int, int)> antinodesPart1 = [];
        HashSet<(int, int)> antinodesPart2 = [];
        var antennas = grid.AllGridMembers().Where(g => g != '.').GroupBy(g => g.Value);
        foreach (var antennaGroup in antennas)
        {
            foreach (var antenna1 in antennaGroup)
            {
                foreach (var antenna2 in antennaGroup.Where(a => a.Location != antenna1.Location))
                {
                    for (int i = 0; i <= 1000; i++)
                    {
                        var antinodeLocation = ((i + 1) * antenna1.X - i * antenna2.X, (i + 1) * antenna1.Y - i * antenna2.Y);
                        if (grid[antinodeLocation.Item1, antinodeLocation.Item2].Found)
                        {
                            antinodesPart2.Add(antinodeLocation);
                            if (i == 1)
                            {
                                antinodesPart1.Add(antinodeLocation);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        Result = (antinodesPart1.Count, antinodesPart2.Count).ToString();
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............";

    public override int Nummer => 202408;
}