using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2021
{
    internal class Dag11 : Problem
    {
        private const string input = @"2478668324
4283474125
1663463374
1738271323
4285744861
3551311515
8574335438
7843525826
1366237577
3554687226";
        public override Task ExecuteAsync()
        {
            var grid = new Grid<int>();
            int i = 0;
            foreach (var line in input.Split(Environment.NewLine))
            {
                int j = 0;
                foreach (var c in line)
                {
                    grid[i, j] = int.Parse(c.ToString());
                    j++;
                }
                i++;
            }

            var gridCount = grid.AllMembers().Count();

            long result = 0;
            int count = 1;
            while(true)
            {
                var flashed = Step();
                if (count <= 100)
                {
                    result += flashed;
                }

                if (flashed == gridCount)
                {
                    break;
                }

                count++;
            }

            int Step()
            {
                HashSet<(int x, int y)> flashed = new HashSet<(int x, int y)>();
                IList<(int, int)> newFlashed = new List<(int, int)>();
                foreach (var member in grid.AllMembers())
                {
                    grid[member.x, member.y]++;
                    if (member.value >= 9)
                    {
                        newFlashed.Add((member.x, member.y));
                        flashed.Add((member.x, member.y));
                    }
                }
                while (newFlashed .Any())
                {
                    IList<(int, int)> newNewFlashed = new List<(int, int)>();
                    foreach (var member in newFlashed)
                    {
                        foreach (var neighbour in grid.Neighbours(member, true))
                        {
                            grid[neighbour.X, neighbour.Y]++;
                            if (neighbour.Value >= 9 && !flashed.Contains((neighbour.X, neighbour.Y)))
                            {
                                newNewFlashed.Add((neighbour.X, neighbour.Y));
                                flashed.Add((neighbour.X, neighbour.Y));
                            }
                        }
                    }

                    newFlashed = newNewFlashed;
                }

                foreach (var member in flashed)
                {
                    grid[member.x, member.y] = 0;
                }

                return flashed.Count;
            }

            Result = $"{result}  {count}";
            return Task.CompletedTask;
        }

        public override int Nummer => 202111;
    }
}
