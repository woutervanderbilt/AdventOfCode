using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag11 : Problem
{
    private const string testinput = @"...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....";
    public override async Task ExecuteAsync()
    {
        IList<(int, int)> galaxies = new List<(int, int)>();
        HashSet<int> usedX = new HashSet<int>();
        HashSet<int> usedY = new HashSet<int>();

        int y = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            int x = 0;
            foreach (var c in line)
            {
                if (c == '#')
                {
                    galaxies.Add((x, y));
                    usedX.Add(x);
                    usedY.Add(y);
                }
                x++;
            }

            y++;
        }

        Result = (ComputeTotalDistance(2), ComputeTotalDistance(1000000)).ToString();

        long ComputeTotalDistance(int expansion)
        {
            IList<(int, int)> expandedGalaxies = new List<(int, int)>();
            foreach (var galaxy in galaxies)
            {
                var xCount = usedX.Count(x => x < galaxy.Item1);
                var yCount = usedY.Count(y => y < galaxy.Item2);
                expandedGalaxies.Add((expansion * (galaxy.Item1 - xCount) + xCount, expansion * (galaxy.Item2 - yCount) + yCount));
            }

            long result = 0;
            foreach (var g1 in expandedGalaxies)
            {
                foreach (var g2 in expandedGalaxies)
                {
                    result += Math.Abs(g1.Item1 - g2.Item1) + Math.Abs(g1.Item2 - g2.Item2);
                }
            }

            result /= 2;
            return result;
        }
    }

    public override int Nummer => 202311;
}