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
            long depth = 3558;
            (int x, int y) target = (15, 740);
            long mod = 20183;
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
            erosionLevels.Print(Map);
            Result = (erosionLevels.AllMembers().Sum(e => e.value % 3) - erosionLevels[target.x, target.y] % 3).ToString();
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
