using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015
{
    internal class Dag21 : Problem
    {
        public override Task ExecuteAsync()
        {
            IList<(int, int, int)> weapons = new List<(int, int, int)>
            {
                (8, 4, 0),
                (10, 5, 0),
                (25, 6, 0),
                (40, 7, 0),
                (74, 8, 0)
            };
            IList<(int, int, int)> armor = new List<(int, int, int)>
            {
                (13, 0, 1),
                (31, 0, 2),
                (53, 0, 3),
                (75, 0, 4),
                (102, 0, 5),
                (0,0,0)
            };
            IList<(int, int, int)> rings = new List<(int, int, int)>
            {
                (25, 1, 0),
                (50, 2, 0),
                (100, 3, 0),
                (20, 0, 1),
                (40, 0, 2),
                (80, 0, 3),
                (0,0,0),
                (0,0,0)
            };

            int minCost = int.MaxValue;
            int maxCost = int.MinValue;
            foreach (var weapon in weapons)
            {
                foreach (var armorpiece in armor)
                {
                    foreach (var ring1 in rings)
                    {
                        foreach (var ring2 in rings)
                        {
                            if (ring1 == (0, 0, 0) && ring2 != (0, 0, 0) || ring1 != (0,0,0) && ring1 == ring2)
                            {
                                continue;
                            }
                            var cost = weapon.Item1 + armorpiece.Item1 + ring1.Item1 + ring2.Item1;
                            if (Fight())
                            {
                                if(cost < minCost)
                                minCost = cost;
                            }
                            else
                            {
                                if (cost > maxCost)
                                {
                                    maxCost = cost;
                                }
                            }

                            bool Fight()
                            {
                                var player = 100;
                                var boss = 104;
                                var playerHit = Math.Max(weapon.Item2 + ring1.Item2 + ring2.Item2 - 1, 1);
                                var bossHit = Math.Max(8 - (armorpiece.Item3 + ring1.Item3 + ring2.Item3), 1);
                                while (player > 0 && boss > 0)
                                {
                                    boss -= playerHit;
                                    player -= bossHit;
                                }

                                return boss <= 0;
                            }
                        }
                    }
                }
            }

            Result = maxCost.ToString();

            return Task.CompletedTask;
        }

        public override int Nummer => 201521;
    }
}
