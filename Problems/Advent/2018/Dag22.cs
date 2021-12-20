using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2018
{
    internal class Dag22 : Problem
    {
        public override Task ExecuteAsync()
        {
            int depth = 3558;
            (int x, int y) target = (15, 740);
            //int depth = 510;
            //(int x, int y) target = (10, 10);
            int mod = 20183;
            var erosionLevels = new Grid<long>();
            for (int x = 0; x <= target.x; x++)
            {
                for (int y = 0; y <= target.y; y++)
                {
                    if (x == 0)
                    {
                        erosionLevels[x, y] = (y * 48271 + depth) % mod;
                    }
                    else if (y == 0)
                    {
                        erosionLevels[x, y] = (x * 16807 + depth) % mod;
                    }
                    else
                    {
                        erosionLevels[x, y] = (erosionLevels[x-1,y] * erosionLevels[x,y-1] + depth) % mod;
                    }
                }
            }
            //erosionLevels.Print(Map);
            Result = (erosionLevels.AllMembers().Sum(e => e.value % 3) - erosionLevels[target.x, target.y] % 3).ToString();

            IDictionary<(int, int, int), int> counter = new Dictionary<(int, int, int), int>();
            IDictionary<(int, int), int> regionTypes = new Dictionary<(int, int), int>();
            regionTypes[(0, 0)] = 0;
            regionTypes[target] = 0;
            IList<(int x, int y, int d)> lastSteps = new List<(int x, int y, int d)>();
            counter[(0, 0, 1)] = 0;
            lastSteps.Add((0,0,1));
            int min = 0;
            var minAtTarget = int.MaxValue;
            while (min < minAtTarget)
            {
                min = int.MaxValue;
                var copy = lastSteps.ToList();
                lastSteps = new List<(int, int, int)>();
                foreach (var lastStep in copy)
                {
                    var currentCost = counter[lastStep];
                    foreach (var neighbour in Neighbours())
                    {
                        if (!counter.ContainsKey(neighbour.value) ||
                            counter[neighbour.value] > currentCost + neighbour.cost)
                        {
                            counter[neighbour.value] = currentCost + neighbour.cost;
                            min = Math.Min(min, currentCost + neighbour.cost);
                            if (neighbour.value == (target.x, target.y, 1))
                            {
                                minAtTarget = Math.Min(minAtTarget, currentCost + neighbour.cost);
                            }
                            lastSteps.Add(neighbour.value);
                        }
                    }

                    IEnumerable<((int x, int y, int d) value, int cost)> Neighbours()
                    {
                        var type = RegionType(lastStep.x, lastStep.y) % 3;
                        if (type == 0)
                        {
                            yield return ((lastStep.x, lastStep.y, lastStep.d == 1 ? 2 : 1), 7);
                        }
                        else if (type == 1)
                        {
                            yield return ((lastStep.x, lastStep.y, lastStep.d == 0 ? 2 : 0), 7);
                        }
                        else if (type == 2)
                        {
                            yield return ((lastStep.x, lastStep.y, lastStep.d == 0 ? 1 : 0), 7);
                        }
                        var neighbourType = RegionType(lastStep.x + 1, lastStep.y) % 3;
                        if (lastStep.d == 0 && neighbourType is 1 or 2
                            || lastStep.d == 1 && neighbourType is 0 or 2
                            || lastStep.d == 2 && neighbourType is 0 or 1)
                        {
                            yield return ((lastStep.x + 1, lastStep.y, lastStep.d), 1);
                        }
                        neighbourType = RegionType(lastStep.x, lastStep.y + 1) % 3;
                        if (lastStep.d == 0 && neighbourType is 1 or 2
                            || lastStep.d == 1 && neighbourType is 0 or 2
                            || lastStep.d == 2 && neighbourType is 0 or 1)
                        {
                            yield return ((lastStep.x, lastStep.y + 1, lastStep.d), 1);
                        }

                        if (lastStep.x > 0)
                        {
                            neighbourType = RegionType(lastStep.x - 1, lastStep.y) % 3;
                            if (lastStep.d == 0 && neighbourType is 1 or 2
                                || lastStep.d == 1 && neighbourType is 0 or 2
                                || lastStep.d == 2 && neighbourType is 0 or 1)
                            {
                                yield return ((lastStep.x - 1, lastStep.y, lastStep.d), 1);
                            }
                        }

                        if (lastStep.y > 0)
                        {
                            neighbourType = RegionType(lastStep.x, lastStep.y -1) % 3;
                            if (lastStep.d == 0 && neighbourType is 1 or 2
                                || lastStep.d == 1 && neighbourType is 0 or 2
                                || lastStep.d == 2 && neighbourType is 0 or 1)
                            {
                                yield return ((lastStep.x, lastStep.y - 1, lastStep.d), 1);
                            }
                        }
                        
                    }

                }
            }



            int RegionType(int x, int y)
            {
                if (regionTypes.ContainsKey((x, y)))
                {
                    return regionTypes[(x, y)];
                }

                int erosionLevel;
                if (x == 0)
                {
                    erosionLevel = (y * 48271 + depth) % mod;
                }
                else if (y == 0)
                {
                    erosionLevel = (x * 16807 + depth) % mod;
                }
                else
                {
                    erosionLevel = (RegionType(x - 1, y) * RegionType(x, y - 1) + depth) % mod;
                }
                regionTypes[(x,y)] = erosionLevel;
                return erosionLevel;
            }


            Result += " " + minAtTarget;







            return Task.CompletedTask;

            char Map(long e)
            {
                return (e % 3) switch
                {
                    0 => '.',
                    1 => '=',
                    2 => '|'
                };
            }
        }

        public override int Nummer => 201822;
    }
}
