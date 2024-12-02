using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag18 : Problem
{
    private const string testinput = @"2,2,2
1,2,2
3,2,2
2,1,2
2,3,2
2,2,1
2,2,3
2,2,4
2,2,6
1,2,5
3,2,5
2,1,5
2,3,5";
    public override async Task ExecuteAsync()
    {
        HashSet<(int x, int y, int z)> grid = new HashSet<(int, int, int)>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var coordinates = line.Split(',');
            grid.Add((int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2])));
        }

        int count = 0;
        foreach (var cube in grid)
        {
            if (!grid.Contains((cube.x + 1, cube.y, cube.z)))
            {
                count++;
            }
            if (!grid.Contains((cube.x - 1, cube.y, cube.z)))
            {
                count++;
            }
            if (!grid.Contains((cube.x, cube.y + 1, cube.z)))
            {
                count++;
            }
            if (!grid.Contains((cube.x, cube.y - 1, cube.z)))
            {
                count++;
            }
            if (!grid.Contains((cube.x, cube.y, cube.z + 1)))
            {
                count++;
            }
            if (!grid.Contains((cube.x, cube.y, cube.z - 1)))
            {
                count++;
            }
        }

        var minx = grid.Min(c => c.x) - 1;
        var maxx = grid.Max(c => c.x) + 1;
        var miny = grid.Min(c => c.y) - 1;
        var maxy = grid.Max(c => c.y) + 1;
        var minz = grid.Min(c => c.z) - 1;
        var maxz = grid.Max(c => c.z) + 1;

        HashSet<(int x, int y, int z)> reachable = new HashSet<(int, int, int)>();
        (int x, int y, int z) start = (minx, miny, minz);
        reachable.Add(start);
        IList<(int x, int y, int z)> lastAdded = new List<(int x, int y, int z)> { start };
        while (lastAdded.Any())
        {
            IList<(int x, int y, int z)> newLastAdded = new List<(int x, int y, int z)>();
            foreach (var cube in lastAdded)
            {
                var neighbour = (cube.x + 1, cube.y, cube.z);
                if (cube.x <= maxx)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
                neighbour = (cube.x - 1, cube.y, cube.z);
                if (cube.x >= minx)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
                neighbour = (cube.x, cube.y + 1, cube.z);
                if (cube.y <= maxy)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
                neighbour = (cube.x, cube.y - 1, cube.z);
                if (cube.y >= miny)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
                neighbour = (cube.x, cube.y, cube.z + 1);
                if (cube.z <= maxz)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
                neighbour = (cube.x, cube.y, cube.z - 1);
                if (cube.z >= minz)
                {
                    if (!reachable.Contains(neighbour) && !grid.Contains(neighbour))
                    {
                        newLastAdded.Add(neighbour);
                        reachable.Add(neighbour);
                    }
                }
            }

            lastAdded = newLastAdded;
        }

        int count2 = 0;
        foreach (var cube in grid)
        {
            if (reachable.Contains((cube.x + 1, cube.y, cube.z)))
            {
                count2++;
            }
            if (reachable.Contains((cube.x - 1, cube.y, cube.z)))
            {
                count2++;
            }
            if (reachable.Contains((cube.x, cube.y + 1, cube.z)))
            {
                count2++;
            }
            if (reachable.Contains((cube.x, cube.y - 1, cube.z)))
            {
                count2++;
            }
            if (reachable.Contains((cube.x, cube.y, cube.z + 1)))
            {
                count2++;
            }
            if (reachable.Contains((cube.x, cube.y, cube.z - 1)))
            {
                count2++;
            }
        }


        Result = (count, count2).ToString();
    }

    public override int Nummer => 202218;
}