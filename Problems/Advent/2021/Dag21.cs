using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2021
{
    internal class Dag21 : Problem
    {
        public override Task ExecuteAsync()
        {
            var x = 2;
            var y = 10;
            var sx = 0;
            var sy = 0;
            var r = 0;
            var rollCount = 0;
            bool t = true;
            while (sx < 1000 && sy < 1000)
            {
                int roll = 0;
                for (int i = 0; i < 3; i++)
                {
                    Roll();
                }
                if (t)
                {
                    x = (x + roll) % 10;
                    x = x == 0 ? 10 : x;
                    sx += x;
                }
                else
                {
                    y = (y + roll) % 10;
                    y = y == 0 ? 10 : y;
                    sy += y;
                }
                rollCount += 3;
                t = !t;

                void Roll()
                {
                    r++;
                    if (r == 101)
                    {
                        r = 1;
                    }
                    roll += r;
                }
            }
            var counter = new CounterLong<(int x, int y, int scoreX, int scoreY)>();
            counter[(2, 10, 0, 0)] = 1;
            bool added = true;
            bool playerXsTurns = true;
            long xWins = 0;
            long yWins = 0;
            IDictionary<int, int> multiples = new Dictionary<int, int>
            {
                { 3, 1 },
                { 4, 3 },
                { 5, 6 },
                { 6, 7 },
                { 7, 6 },
                { 8, 3 },
                { 9, 1 }
            };
            while (added)
            {
                added = false;
                var newCounter = new CounterLong<(int x, int y, int scoreX, int scoreY)>();
                foreach (var key in counter.Keys)
                {
                    var value = counter[key];
                    if (key.scoreX >= 21)
                    {
                        xWins += value;
                        continue;
                    }
                    if (key.scoreY >= 21)
                    {
                        yWins += value;
                        continue;
                    }

                    added = true;
                    if (playerXsTurns)
                    {
                        for (int i = 3; i <= 9; i++)
                        {
                            var newX = (key.x + i) % 10;
                            newX = newX == 0 ? 10 : newX;
                            newCounter[(newX, key.y, key.scoreX + newX, key.scoreY)] += multiples[i] * value;
                        }
                    }
                    else
                    {
                        for (int i = 3; i <= 9; i++)
                        {
                            var newY = (key.y + i) % 10;
                            newY = newY == 0 ? 10 : newY;
                            newCounter[(key.x, newY, key.scoreX, key.scoreY + newY)] += multiples[i] * value;
                        }
                    }
                }

                counter = newCounter;
                playerXsTurns = !playerXsTurns;
            }

            Result = $"{rollCount * (sx < 1000 ? sx : sy)}  {Math.Max(xWins, yWins)}";
            return Task.CompletedTask;
        }

        public override int Nummer => 202121;
    }
}
